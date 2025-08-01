using System.Text;
using System.Text.Json;
using Proposal.Application.Ports.Outbound.Messaging;
using Proposal.Domain.Events;
using RabbitMQ.Client;

namespace Proposal.Infra.Messaging
{
    public class MessageSender : IMessageSender
    {
        private readonly IChannel _channel;
        public MessageSender(IChannel channel)
        {
            _channel = channel;
        }

        public async Task SendMessageHireProposalAsync(ProposalHireEvent @event)
        {
            var json = JsonSerializer.Serialize(@event);

            var body = Encoding.UTF8.GetBytes(json);

            await _channel.BasicPublishAsync(exchange: "seguro.plataform", routingKey: "proposal.hire", body: body);
        }
    }
}
