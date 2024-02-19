using System.Collections.Concurrent;
using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.loja.Configuration;
using RabbitMQ.loja.Interfaces;
using System.Text.Json;
using System.Net.Http.Json;
using Dominio.loja.Dto.RabbitMQ;
using Microsoft.AspNetCore.Http;

namespace RabbitMQ.loja 
{
    public class FileUploadClient : IDisposable , IFileUploadClient
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;
        private readonly IConfiguration _configuration;
        private readonly ConnectionFactory _factory;
        private readonly ConcurrentDictionary<string, TaskCompletionSource<string>> callbackMapper = new();
        public FileUploadClient()
        {
            Configurations config = new Configurations();
            IConfiguration _configuration = config._configuration;

            _factory = new ConnectionFactory { HostName = _configuration.GetSection("UploadQueue:QueueName").Value };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            // declare a server-named queue
            
            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += (model, ea) =>
            {
                if (!callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                    return;
                var body = ea.Body.ToArray();
                var response = Encoding.UTF8.GetString(body);
                tcs.TrySetResult(response);
            };

            _channel.BasicConsume(consumer: _consumer,
                                 queue: _channel.QueueDeclare().QueueName,
                                 autoAck: true);
        }

        public Task<string> CallAsync(UploadQueueRequest message, CancellationToken cancellationToken = default)
        {
            IBasicProperties props = _channel.CreateBasicProperties();
            var correlationId = Guid.NewGuid().ToString();
            props.CorrelationId = correlationId;
            props.ReplyTo = _channel.QueueDeclare().QueueName;
            var messageBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            
            var tcs = new TaskCompletionSource<string>();
            callbackMapper.TryAdd(correlationId, tcs);

            _channel.BasicPublish(exchange: string.Empty,
                                 routingKey: _configuration.GetSection("UploadQueue:QueueName").Value,
                                 basicProperties: props,
                                 body: messageBytes);

            cancellationToken.Register(() => callbackMapper.TryRemove(correlationId, out _));
            
            return tcs.Task;
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public UploadQueueRequest GetUploadQueueRequest(IFormFile formFile, FileInfo fileInfo )
        {
            return new UploadQueueRequest(formFile ,fileInfo);
        }
    }
}

