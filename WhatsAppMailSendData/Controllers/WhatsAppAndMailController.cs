using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net.Http;
using WhatsAppMailSendData.AppCodeGlobal;
using WhatsAppMailSendData.Model;
using WhatsAppMailSendData.Service;

namespace WhatsAppMailSendData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class WhatsAppAndMailController : ControllerBase
    {

        private static readonly HttpClient _httpClient = new HttpClient();
        [HttpGet("opt-in")]
        public async Task<string> WhatsappOptIn(string mobile, string secretkey)
        {
            if (secretkey != GlobalEntities.SecretKey)
            {
                return "secret key not valid";
            }

            WhatsApp wModel = new WhatsApp();
            wModel.SendTo = mobile; // Replace with the phone number you want to opt in
            wModel.AuthSchema = "plain";
            wModel.Channel = "WHATSAPP";
            wModel.Version = "1.1";
            wModel.Format = "json";
            wModel.Method = "OPT_IN";
            return await WhatsAppService.OptIn(wModel);
        }

        [HttpGet("send-template")]
        public async Task<string> WhatsappSendTemplate(string mobile, string templateId, string secretkey)
        {
            if (secretkey != GlobalEntities.SecretKey)
            {
                return "secret key not valid";
            }

            WhatsApp wModel = new WhatsApp();
            wModel.SendTo = mobile; // Replace with the phone number you want to opt in
            wModel.AuthSchema = "plain";
            wModel.Version = "1.1";
            wModel.Method = "SendMessage";
            wModel.Message = "this is test template message";
            return await WhatsAppService.SendTemplate(wModel);
        }

        [HttpGet("send-message")]
        public async Task<string> WhatsappSendMessage(string mobile, string message, string secretkey)
        {
            if (secretkey != GlobalEntities.SecretKey)
            {
                return "secret key not valid";
            }

            WhatsApp wModel = new WhatsApp();
            wModel.SendTo = mobile; // Replace with the phone number you want to opt in
            wModel.AuthSchema = "plain";
            wModel.Version = "1.1";
            wModel.MessageType = "DATA_TEXT";
            wModel.Method = "SendMessage";
            wModel.Message = message;
            return await WhatsAppService.SendMessage(wModel);
        }

        [HttpGet]
        [Route("/default/api/start-cronjob")]
        public string StartCronJob()
        {
            if (GlobalEntities.IsCronJobRunning)
            {
                return "CronJob Already Running";
            }
            else
            {
                CronJob cs = new CronJob();
                GlobalEntities.IsCronJobRunning = true;
                return "Cronjob Started";
            }
        }
        
        [HttpGet]
        [Route("/default/api/sendwhatsappmessage")]
        public async Task<string> SendWhatsappMessage(string mobile)
        {
            string wht1message = $"https://media.smsgupshup.com/GatewayAPI/rest?userid={GlobalEntities.WUserId}&password={GlobalEntities.WPassword}&send_to={mobile}&v=1.1&format=json&msg_type=TEXT&method=SENDMESSAGE&msg=Hello+Sir%0AANPR+Alert+from+VMS+Camera+Id+%3A+16+%2C+Camera+Name%3A+ICCC%2C+Camera+Location%3A+Delhi ";
            var wht1 = await _httpClient.GetStringAsync(wht1message);

            return "OK";
        }


    }
}
