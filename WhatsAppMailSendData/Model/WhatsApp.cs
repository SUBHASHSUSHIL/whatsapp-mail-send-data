using WhatsAppMailSendData.AppCodeGlobal;

namespace WhatsAppMailSendData.Model
{
    public class WhatsApp
    {
        public string APIURL { get; set; } = "https://media.smsgupshup.com/GatewayAPI/rest";
        public string UserId { get; set; } = GlobalEntities.WUserId;
        public string Password { get; set; } = GlobalEntities.WPassword;
        public string Channel { get; set; } = "nB$yvp4U";
        public string AuthSchema { get; set; } = "plain";
        public string Version { get; set; } = "1.1";
        public string Format { get; set; } = "text";
        public string Method { get; set; } = "SendMessage";
        public string SendTo { get; set; }
        public string MessageType { get; set; } = "DATA_TEXT";
        public string Message { get; set; }
        public string MediaURL { get; set; }
        public string DataEncoding { get; set; } = "text";
        public bool IsHSM { get; set; } = false;
        public string hsmTemplateId { get; set; }
    }
}
