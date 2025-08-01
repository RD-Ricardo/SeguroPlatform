using System.Text;
using RabbitMQ.Client;
using System.Text.Json;
using RabbitMQ.Client.Events;
using Hiring.Application.Ports.Inbound.UseCases.CreateHiring;

namespace Hiring.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IServiceProvider _serviceProvider;

        private readonly IChannel _channel;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider, IChannel channel)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _channel = channel;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false);

            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.ReceivedAsync += async (model, ea) =>
            {
               byte[] body = ea.Body.ToArray();
                    
               var message = Encoding.UTF8.GetString(body);

               using var scope = _serviceProvider.CreateScope();

               var createHiringUseCase = scope.ServiceProvider.GetRequiredService<ICreateHiringUseCase>();

               var @event = JsonSerializer.Deserialize<ProposalHireCreateDto>(message);

                _logger.LogInformation("Received message: {Message}", message);

                await createHiringUseCase.ExecuteAsync(@event!);
            };

            await _channel.BasicConsumeAsync("proposal.hire.queue", autoAck: false, consumer: consumer);

        }
    }
}
