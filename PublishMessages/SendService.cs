using System.Reflection;
using System.Text;
using System.Threading.Channels;
using RabbitMQ.Client;
using SmartBoardWebAPI.Utils;

namespace PublishMessages
{
    public class SendService : ISendService
    {
        private ILogWriter _log;

        public SendService(ILogWriter log) {
            _log = log;
        }

        public async Task<bool> SendMessage(string json, Header header)
        {
            var success = false;
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var model = connection.CreateModel();
            var properties = model.CreateBasicProperties();

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("ELEMENT", header.Element.ToString());
            dictionary.Add("TRANSACTIONTYPE", header.TransactionType.ToString());
            dictionary.Add("MULTIPLE", header.Multiple.ToString());

            properties.Persistent = false;
            properties.Headers = dictionary;

            model.ConfirmSelect();

            model.QueueDeclare(queue: "SmartBoard",
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            var body = Encoding.UTF8.GetBytes(json);

            model.BasicPublish(string.Empty, "SmartBoard", properties, body);

            model.BasicAcks += (sender, ea) =>
            {
                success = true;

                Console.WriteLine($" [x] Sent {json}");

                _log.LogWrite("$[x] Sent {message}");
            };
            model.BasicNacks += (sender, ea) =>
            {
                success = false;

                Console.WriteLine($" [x] Not Sent! Sent {json}");

                _log.LogWrite("$[x] Message Not Sent! {message}");
            };

            model.WaitForConfirmsOrDie(TimeSpan.FromSeconds(5));

            return success;
        }
    }
}

