using RabbitMQ.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proposal.Application.Ports.Outbound.Messaging;
using SeguroPlataform.Common.Configuration;

namespace Proposal.Infra.Messaging
{
    public static class MessagingAmqpConfiguration
    {
        public static void ConfigureAmqp(this IServiceCollection services, IConfiguration configuration)
        {
            var channel = services.CreateAmqpChannel(configuration).GetAwaiter().GetResult();

            channel.ExchangeDeclareAsync(
                exchange: "seguro.plataform",
                type: ExchangeType.Topic,
                durable: true,
                autoDelete: false).Wait();

            channel.QueueDeclareAsync(
                queue: "proposal.hire.queue",
                durable: true,
                exclusive: false,
                autoDelete: false).Wait();

            channel.QueueBindAsync(
                queue: "proposal.hire.queue",
                exchange: "seguro.plataform",
                routingKey: "proposal.hire").Wait();

            services.AddScoped<IMessageSender, MessageSender>(e => new MessageSender(channel));
        }
    }
}
