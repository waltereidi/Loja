using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.loja.Configuration;
using System.Text;
using System.Threading.Channels;

namespace RabbitMQ.loja
{
    public class FileUploadServer
    {

        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IConfiguration _configuration;
        private EventingBasicConsumer _consumer { get; set; }
        public FileUploadServer(string hostname)
        {
            Configurations config = new Configurations();
            _configuration = config._configuration;

            _factory = new ConnectionFactory { HostName = _configuration.GetSection("UploadQueue:HostName").Value };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _configuration.GetSection("UploadQueue:QueueName").Value,
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            _consumer = new EventingBasicConsumer(_channel);
            _channel.BasicConsume(queue: _configuration.GetSection("UploadQueue:QueueName").Value,
                                 autoAck: false,
                                 consumer: _consumer);

            //For each message received execute the code below
            _consumer.Received += (model, ea) =>
            {
                string response = string.Empty;

                var body = ea.Body.ToArray();
                var props = ea.BasicProperties;
                var replyProps = _channel.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;

                try
                {
                    response = Encoding.UTF8.GetString(body);
                    //Add code to be done here
                }
                catch (Exception e)
                {
                    response = string.Empty;
                }
                finally
                {
                    //Send back the response to the caller.
                    var responseBytes = Encoding.UTF8.GetBytes(response);
                    _channel.BasicPublish(exchange: string.Empty,
                                         routingKey: props.ReplyTo,
                                         basicProperties: replyProps,
                                         body: responseBytes);
                    _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
            };
        }


    }
}
