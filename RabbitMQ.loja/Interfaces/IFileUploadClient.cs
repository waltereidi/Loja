using Dominio.loja.Dto.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.loja.Interfaces
{
    /// <summary>
    /// RabbitMQ FileUpload Client ,<br></br> 
    /// this client is responsible to send to FileUploadServer
    ///     UploadQueueRequest should be generated from GetUploadQueuRequest<br></br>
    /// <see cref="RabbitMQ Documentation" href="https://www.rabbitmq.com/tutorials/tutorial-six-dotnet.html"/>
    /// </summary>
    public interface IFileUploadClient
    {
        
        void Dispose();
        /// <summary>
        ///     Sends a message to be processed on the server side and retrieves its response
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> CallAsync(UploadQueueRequest message, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Retrieves the model to be used for CallAsync
        /// </summary>
        /// <returns></returns>
        UploadQueueRequest GetUploadQueueRequest();

    }
}
