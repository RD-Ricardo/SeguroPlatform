namespace SeguroPlataform.Common.Settigns
{
    public class AmqpSettings
    {
        public string Host { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string VirtualHost { get; set; } = null!;
        public int Port { get; set; }
    }
}
