using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJobsTemplate
{
    /// <summary>
    /// Receiver para usar fila em Service Bus
    /// </summary>
    public class MessageReceiverCliente
    {
        private readonly ILogger<MessageReceiverCliente> _logger;
        public MessageReceiverCliente(ILogger<MessageReceiverCliente> logger)
        {
            _logger = logger;
        }
        public Task HandleMessage([ServiceBusTrigger("teste")] Message message, MessageReceiver messageReceiver)
        {
            try
            {
                _logger.LogInformation("Received message with ID {0}.", message.MessageId);
                var text = Encoding.UTF8.GetString(message.Body);
                //var thingy = JsonConvert.DeserializeObject<Thingy>(text);
                _logger.LogInformation($"Received: {text}");
                //complete the message if there is no error
                messageReceiver.CompleteAsync(message.SystemProperties.LockToken);              
            }
            catch (Exception ex)
            {
                // Do your error handling here
                _logger.LogInformation($"Erro: {ex.Message}");

                // Send message to DeadLetter Queue 
                messageReceiver.DeadLetterAsync(message.SystemProperties.LockToken);
            }
            return Task.CompletedTask;
        }
    }
}
