using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using SeguroPlataform.Common.Settigns;

namespace SeguroPlataform.Common.Configuration
{
    public static  class RabbitConfiguration
    {
        public static async Task<IChannel> CreateAmqpChannel(this IServiceCollection services, IConfiguration configuration)
        {
            var amqpSettings = configuration.GetSection("AmqpSettings").Get<AmqpSettings>()!;

            var factory = new ConnectionFactory
            {
                HostName = amqpSettings.Host!,
                Password = amqpSettings.Password!,
                UserName = amqpSettings.UserName!,
                Port = amqpSettings.Port,
                RequestedConnectionTimeout = TimeSpan.FromSeconds(30),
                VirtualHost = amqpSettings.VirtualHost!

            };

            int retryCount = 5;
            int delay = 3000;

            for (int i = 0; i < retryCount; i++)
            {
                try
                {
                     await factory.CreateConnectionAsync();
                }
                catch (BrokerUnreachableException)
                {
                    if (i == retryCount - 1) throw;
                    Thread.Sleep(delay);
                }
            }

            services.AddSingleton(factory);

            var connection = await factory.CreateConnectionAsync();

            services.AddSingleton(connection);

            var channel = await connection.CreateChannelAsync();

            services.AddSingleton(channel);

            return channel;
        }

    }
}
