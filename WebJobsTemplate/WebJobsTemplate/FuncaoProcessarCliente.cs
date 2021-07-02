using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace WebJobsTemplate
{
    /// <summary>
    /// Listener para processar mensagens na fila uma usam storage account
    /// </summary>
    public class FuncaoProcessarCliente
    {
        //public static void processservicebus([ServiceBusTrigger("test", Connection = "ServiceBusConnection")] string myQueueItem, ILogger log)
        //{
        //    log.LogInformation(myQueueItem);
        //}

        //Descomentar para triqer por fila em storage account
        //public static void ProcessQueueMessage([QueueTrigger(Contantes.FilaCliente)] string message, ILogger logger)
        //{
        //    logger.LogInformation(message);
        //}

        //    public static void ProcessQueueMessage(
        //[QueueTrigger("queue")] string message,
        //[Blob("container/{queueTrigger}", FileAccess.Read)] Stream myBlob,
        //ILogger logger)
        //    {
        //        logger.LogInformation($"Blob name:{message} \n Size: {myBlob.Length} bytes");
        //    }


        //Copia de blob
        //    public static void ProcessQueueMessage(
        //[QueueTrigger("queue")] string message,
        //[Blob("container/{queueTrigger}", FileAccess.Read)] Stream myBlob,
        //[Blob("container/copy-{queueTrigger}", FileAccess.Write)] Stream outputBlob,
        //ILogger logger)
        //    {
        //        logger.LogInformation($"Blob name:{message} \n Size: {myBlob.Length} bytes");
        //        myBlob.CopyTo(outputBlob);
        //    }
    }
}
