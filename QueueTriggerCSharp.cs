using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionAppDevHello;

public class QueueTriggerCSharp
{
    private readonly ILogger<QueueTriggerCSharp> _logger;

    public QueueTriggerCSharp(ILogger<QueueTriggerCSharp> logger)
    {
        _logger = logger;
    }

    [Function(nameof(QueueTriggerCSharp))]
    public void Run([QueueTrigger("myqueue-items", Connection = "QueueStorage")] QueueMessage message)
    {
        _logger.LogInformation("C# Queue trigger function processed: {messageText}", message.MessageText);
    }
}