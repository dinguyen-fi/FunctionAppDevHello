using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionAppDevHello;

public class QueueTrigger
{
    private readonly ILogger _logger;

    public QueueTrigger(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<QueueTrigger>();
    }

    [Function("CopyQueueMessage")]
    [QueueOutput("myqueue-items-destination", Connection = "QueueStorage")]
    public string Run([QueueTrigger("myqueue-items-source", Connection = "QueueStorage")] string myQueueItem)
    {
        _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        return myQueueItem;
    }

}