using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using WhatsAppMailSendData.AppCodeGlobal;
using WhatsAppMailSendData.Model;

namespace WhatsAppMailSendData.Service
{
    public class CronJob
    {
        private Timer timer;
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string _apiUrl = "http://mpexcise.ecosmartdc.com:6004";

        public CronJob()
        {        
            timer = new Timer(CheckSchedule, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

        }

        private void CheckSchedule(object state)
        {
            DateTime now = DateTime.Now;
            if (now.Second == 0)
            {
                Task.Run(() => ExecuteTask());
                Task.Run(() => ExecuteTask2());
            }
        }

        private async Task ExecuteTask()
        {
            string apicall = _apiUrl + $"/api/CameraTrackingData/Pagination?dateFrom={DateTime.Now.AddMinutes(-1).ToString("yyyy-MM-ddTHH:mm:ss")}&dateTo={DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}&orderBy=Id&orderType=desc";
            try
            {
                var response = await _httpClient.GetStringAsync(apicall);
                cmtdata cmtdadsad = JsonSerializer.Deserialize<cmtdata>(response);

                List<CameraTrackingData> cameraList = cmtdadsad.cameraTrackingData;

                if (cameraList != null && cameraList.Count() > 0)
                {
                    WhatsApp wModel = new WhatsApp();
                    wModel.SendTo = GlobalEntities.MobileNumber; // Replace with the phone number you want to opt in
                    wModel.AuthSchema = "plain";
                    wModel.Channel = "WHATSAPP";
                    wModel.Version = "1.1";
                    wModel.Format = "json";
                    wModel.Method = "OPT_IN";
                    await WhatsAppService.OptIn(wModel);

                    WhatsApp wModel2 = new WhatsApp();
                    wModel2.SendTo = GlobalEntities.MobileNumber2; // Replace with the phone number you want to opt in
                    wModel2.AuthSchema = "plain";
                    wModel2.Channel = "WHATSAPP";
                    wModel2.Version = "1.1";
                    wModel2.Format = "json";
                    wModel2.Method = "OPT_IN";
                    await WhatsAppService.OptIn(wModel2);

                    WhatsApp wModel3 = new WhatsApp();
                    wModel3.SendTo = GlobalEntities.MobileNumber3; // Replace with the phone number you want to opt in
                    wModel3.AuthSchema = "plain";
                    wModel3.Channel = "WHATSAPP";
                    wModel3.Version = "1.1";
                    wModel3.Format = "json";
                    wModel3.Method = "OPT_IN";
                    await WhatsAppService.OptIn(wModel3);

                    WhatsApp wModel4 = new WhatsApp();
                    wModel4.SendTo = GlobalEntities.MobileNumber4; // Replace with the phone number you want to opt in
                    wModel4.AuthSchema = "plain";
                    wModel4.Channel = "WHATSAPP";
                    wModel4.Version = "1.1";
                    wModel4.Format = "json";
                    wModel4.Method = "OPT_IN";
                    await WhatsAppService.OptIn(wModel4);

                    WhatsApp wModel5 = new WhatsApp();
                    wModel5.SendTo = GlobalEntities.MobileNumber5; // Replace with the phone number you want to opt in
                    wModel5.AuthSchema = "plain";
                    wModel5.Channel = "WHATSAPP";
                    wModel5.Version = "1.1";
                    wModel5.Format = "json";
                    wModel5.Method = "OPT_IN";
                    await WhatsAppService.OptIn(wModel5);
                    //Thread.Sleep(1000);


                    foreach (var rdata in cameraList)
                    {
                        string wht1message = $"https://media.smsgupshup.com/GatewayAPI/rest?userid={GlobalEntities.WUserId}&password={GlobalEntities.WPassword}&send_to={GlobalEntities.MobileNumber}&v=1.1&format=json&msg_type=TEXT&method=SENDMESSAGE&msg=Hello+Sir%0AANPR+Alert+from+VMS+Camera+Id+%3A+{rdata.cameraId}+%2C+Camera+Name%3A+{rdata.camera.name}%2C+Camera+Location%3A+{rdata.camera.Location} ";
                        var wht1 = await _httpClient.GetStringAsync(wht1message);

                        string wht2message = $"https://media.smsgupshup.com/GatewayAPI/rest?userid={GlobalEntities.WUserId}&password={GlobalEntities.WPassword}&send_to={GlobalEntities.MobileNumber2}&v=1.1&format=json&msg_type=TEXT&method=SENDMESSAGE&msg=Hello+Sir%0AANPR+Alert+from+VMS+Camera+Id+%3A+{rdata.cameraId}+%2C+Camera+Name%3A+{rdata.camera.name}%2C+Camera+Location%3A+{rdata.camera.Location} ";
                        var wht2 = await _httpClient.GetStringAsync(wht2message);

                        string wht3message = $"https://media.smsgupshup.com/GatewayAPI/rest?userid={GlobalEntities.WUserId}&password={GlobalEntities.WPassword}&send_to={GlobalEntities.MobileNumber3}&v=1.1&format=json&msg_type=TEXT&method=SENDMESSAGE&msg=Hello+Sir%0AANPR+Alert+from+VMS+Camera+Id+%3A+{rdata.cameraId}+%2C+Camera+Name%3A+{rdata.camera.name}%2C+Camera+Location%3A+{rdata.camera.Location} ";
                        var wht3 = await _httpClient.GetStringAsync(wht3message);

                        string wht4message = $"https://media.smsgupshup.com/GatewayAPI/rest?userid={GlobalEntities.WUserId}&password={GlobalEntities.WPassword}&send_to={GlobalEntities.MobileNumber4}&v=1.1&format=json&msg_type=TEXT&method=SENDMESSAGE&msg=Hello+Sir%0AANPR+Alert+from+VMS+Camera+Id+%3A+{rdata.cameraId}+%2C+Camera+Name%3A+{rdata.camera.name}%2C+Camera+Location%3A+{rdata.camera.Location} ";
                        var wht4 = await _httpClient.GetStringAsync(wht4message);

                        string wht5message = $"https://media.smsgupshup.com/GatewayAPI/rest?userid={GlobalEntities.WUserId}&password={GlobalEntities.WPassword}&send_to={GlobalEntities.MobileNumber5}&v=1.1&format=json&msg_type=TEXT&method=SENDMESSAGE&msg=Hello+Sir%0AANPR+Alert+from+VMS+Camera+Id+%3A+{rdata.cameraId}+%2C+Camera+Name%3A+{rdata.camera.name}%2C+Camera+Location%3A+{rdata.camera.Location} ";
                        var wht5 = await _httpClient.GetStringAsync(wht5message);


                        //SendMail smm = new SendMail();
                        //smm.CustomerName = "mp exise";
                        //smm.CustomerEmail = "vishal.gupta@ajeevi.com";
                        //smm.MailSubject = $"ANPR Alert from cameraId :{rdata.cameraId} - camera Name: {rdata.camera.name} - VichelNo: {rdata.VichelNo}";
                        //smm.MailBody = $"ANPR Alert from cameraId :{rdata.cameraId} <br>camera Name: {rdata.camera.name} <br>VichelImage: <img src='https://anpr.ajeevi.in/{rdata.VichelImage}' /> <br> VichelNo: {rdata.VichelNo}";
                        //MailService.Send2(smm);

                        //SendMail smm2 = new SendMail();
                        //smm2.CustomerName = "mp exise";
                        //smm2.CustomerEmail = "jitendra.rathore@smartbhopal.city";
                        //smm2.MailSubject = $"ANPR Alert from cameraId :{rdata.cameraId} - camera Name: {rdata.camera.name} - VichelNo: {rdata.VichelNo}";
                        //smm2.MailBody = $"ANPR Alert from cameraId :{rdata.cameraId} <br>camera Name: {rdata.camera.name} <br>VichelImage: <img src='https://anpr.ajeevi.in/{rdata.VichelImage}' /> <br> VichelNo: {rdata.VichelNo}";
                        //MailService.Send2(smm2);

                        //SendMail smm3 = new SendMail();
                        //smm3.CustomerName = "mp exise";
                        //smm3.CustomerEmail = "sushilthakur9792@gmail.com";
                        //smm3.MailSubject = $"ANPR Alert from cameraId :{rdata.cameraId} - camera Name: {rdata.camera.name} - VichelNo: {rdata.VichelNo}";
                        //smm3.MailBody = $"ANPR Alert from cameraId :{rdata.cameraId} <br>camera Name: {rdata.camera.name} <br>VichelImage: <img src='https://anpr.ajeevi.in/{rdata.VichelImage}' /> <br> VichelNo: {rdata.VichelNo}";
                        //MailService.Send2(smm3);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        private async Task ExecuteTask2()
        {
            string apicall = _apiUrl + $"/api/CameraAlert/Pagination?dateFrom={DateTime.Now.AddMinutes(-5).ToString("yyyy-MM-ddTHH:mm:ss")}&dateTo={DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}&orderBy=Id&orderType=desc";
            try
            {
                var response = await _httpClient.GetStringAsync(apicall);
                cmtdata cmtdadsad = JsonSerializer.Deserialize<cmtdata>(response);

                List<CameraAlert> cameraList = cmtdadsad.cameraAlertStatuses;

                if (cameraList != null && cameraList.Count() > 0)
                {
                    WhatsApp wModel = new WhatsApp();
                    wModel.SendTo = GlobalEntities.MobileNumber; // Replace with the phone number you want to opt in
                    wModel.AuthSchema = "plain";
                    wModel.Channel = "WHATSAPP";
                    wModel.Version = "1.1";
                    wModel.Format = "json";
                    wModel.Method = "OPT_IN";
                    await WhatsAppService.OptIn(wModel);

                    WhatsApp wModel2 = new WhatsApp();
                    wModel2.SendTo = GlobalEntities.MobileNumber2; // Replace with the phone number you want to opt in
                    wModel2.AuthSchema = "plain";
                    wModel2.Channel = "WHATSAPP";
                    wModel2.Version = "1.1";
                    wModel2.Format = "json";
                    wModel2.Method = "OPT_IN";
                    await WhatsAppService.OptIn(wModel2);

                    WhatsApp wModel3 = new WhatsApp();
                    wModel3.SendTo = GlobalEntities.MobileNumber3; // Replace with the phone number you want to opt in
                    wModel3.AuthSchema = "plain";
                    wModel3.Channel = "WHATSAPP";
                    wModel3.Version = "1.1";
                    wModel3.Format = "json";
                    wModel3.Method = "OPT_IN";
                    await WhatsAppService.OptIn(wModel3);

                    WhatsApp wModel4 = new WhatsApp();
                    wModel4.SendTo = GlobalEntities.MobileNumber4; // Replace with the phone number you want to opt in
                    wModel4.AuthSchema = "plain";
                    wModel4.Channel = "WHATSAPP";
                    wModel4.Version = "1.1";
                    wModel4.Format = "json";
                    wModel4.Method = "OPT_IN";
                    await WhatsAppService.OptIn(wModel4);

                    WhatsApp wModel5 = new WhatsApp();
                    wModel5.SendTo = GlobalEntities.MobileNumber5; // Replace with the phone number you want to opt in
                    wModel5.AuthSchema = "plain";
                    wModel5.Channel = "WHATSAPP";
                    wModel5.Version = "1.1";
                    wModel5.Format = "json";
                    wModel5.Method = "OPT_IN";
                    await WhatsAppService.OptIn(wModel5);


                    foreach (var rdata in cameraList)
                    {
                        string wht1message = $"https://media.smsgupshup.com/GatewayAPI/rest?userid={GlobalEntities.WUserId}&password={GlobalEntities.WPassword}&send_to={GlobalEntities.MobileNumber}&v=1.1&format=json&msg_type=TEXT&method=SENDMESSAGE&msg=Hello+Sir%0AAlert+from+VMS+Camera+Id+%3A+{rdata.CameraId}+%2C+Camera+Name%3A+{rdata.AlertStatus}%2C+Camera+Location%3A+{rdata.ObjectName} ";
                        var wht1 = await _httpClient.GetStringAsync(wht1message);

                        string wht2message = $"https://media.smsgupshup.com/GatewayAPI/rest?userid={GlobalEntities.WUserId}&password={GlobalEntities.WPassword}&send_to={GlobalEntities.MobileNumber2}&v=1.1&format=json&msg_type=TEXT&method=SENDMESSAGE&msg=Hello+Sir%0AANPR+Alert+from+VMS+Camera+Id+%3A+{rdata.CameraId}+%2C+Camera+Name%3A+{rdata.AlertStatus}%2C+Camera+Location%3A+{rdata.ObjectName} ";
                        var wht2 = await _httpClient.GetStringAsync(wht2message);

                        string wht3message = $"https://media.smsgupshup.com/GatewayAPI/rest?userid={GlobalEntities.WUserId}&password={GlobalEntities.WPassword}&send_to={GlobalEntities.MobileNumber3}&v=1.1&format=json&msg_type=TEXT&method=SENDMESSAGE&msg=Hello+Sir%0AANPR+Alert+from+VMS+Camera+Id+%3A+{rdata.CameraId}+%2C+Camera+Name%3A+{rdata.AlertStatus}%2C+Camera+Location%3A+{rdata.ObjectName} ";
                        var wht3 = await _httpClient.GetStringAsync(wht3message);

                        string wht4message = $"https://media.smsgupshup.com/GatewayAPI/rest?userid={GlobalEntities.WUserId}&password={GlobalEntities.WPassword}&send_to={GlobalEntities.MobileNumber4}&v=1.1&format=json&msg_type=TEXT&method=SENDMESSAGE&msg=Hello+Sir%0AANPR+Alert+from+VMS+Camera+Id+%3A+{rdata.CameraId}+%2C+Camera+Name%3A+{rdata.AlertStatus}%2C+Camera+Location%3A+{rdata.ObjectName} ";
                        var wht4 = await _httpClient.GetStringAsync(wht4message);

                        string wht5message = $"https://media.smsgupshup.com/GatewayAPI/rest?userid={GlobalEntities.WUserId}&password={GlobalEntities.WPassword}&send_to={GlobalEntities.MobileNumber5}&v=1.1&format=json&msg_type=TEXT&method=SENDMESSAGE&msg=Hello+Sir%0AANPR+Alert+from+VMS+Camera+Id+%3A+{rdata.CameraId}+%2C+Camera+Name%3A+{rdata.AlertStatus}%2C+Camera+Location%3A+{rdata.ObjectName} ";
                        var wht5 = await _httpClient.GetStringAsync(wht5message);


                        //SendMail smm = new SendMail();
                        //smm.CustomerName = "mp exise";
                        //smm.CustomerEmail = "vishal.gupta@ajeevi.com";
                        //smm.MailSubject = $"ANPR Alert from cameraId :{rdata.cameraId} - camera Name: {rdata.camera.name} - VichelNo: {rdata.VichelNo}";
                        //smm.MailBody = $"ANPR Alert from cameraId :{rdata.cameraId} <br>camera Name: {rdata.camera.name} <br>VichelImage: <img src='https://anpr.ajeevi.in/{rdata.VichelImage}' /> <br> VichelNo: {rdata.VichelNo}";
                        //MailService.Send2(smm);

                        //SendMail smm2 = new SendMail();
                        //smm2.CustomerName = "mp exise";
                        //smm2.CustomerEmail = "jitendra.rathore@smartbhopal.city";
                        //smm2.MailSubject = $"ANPR Alert from cameraId :{rdata.cameraId} - camera Name: {rdata.camera.name} - VichelNo: {rdata.VichelNo}";
                        //smm2.MailBody = $"ANPR Alert from cameraId :{rdata.cameraId} <br>camera Name: {rdata.camera.name} <br>VichelImage: <img src='https://anpr.ajeevi.in/{rdata.VichelImage}' /> <br> VichelNo: {rdata.VichelNo}";
                        //MailService.Send2(smm2);

                        //SendMail smm3 = new SendMail();
                        //smm3.CustomerName = "mp exise";
                        //smm3.CustomerEmail = "sushilthakur9792@gmail.com";
                        //smm3.MailSubject = $"ANPR Alert from cameraId :{rdata.cameraId} - camera Name: {rdata.camera.name} - VichelNo: {rdata.VichelNo}";
                        //smm3.MailBody = $"ANPR Alert from cameraId :{rdata.cameraId} <br>camera Name: {rdata.camera.name} <br>VichelImage: <img src='https://anpr.ajeevi.in/{rdata.VichelImage}' /> <br> VichelNo: {rdata.VichelNo}";
                        //MailService.Send2(smm3);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void Stop()
        {
            timer?.Change(Timeout.Infinite, 0);
        }
    }

    public class cmtdata
    {
        public int totalCount { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public List<CameraTrackingData> cameraTrackingData { get; set; }
        public List<CameraAlert> cameraAlertStatuses { get; set; }
    }

    public class CameraTrackingData
    {
        public int Id { get; set; }
        public Camera? camera { get; set; }
        public int cameraId { get; set; }
        public string? VichelImage { get; set; }
        public string? NoPlateImage { get; set; }
        public string? VichelNo { get; set; }
        public char AlertType { get; set; }
        public bool Status { get; set; } = true;
        public DateTime RegDate { get; set; } = DateTime.Now;
    }

    public class CameraAlert
    {
        public int Id { get; set; }
        public Camera? Camera { get; set; }
        public int CameraId { get; set; }
        public string? FramePath { get; set; }
        public string? ObjectName { get; set; }
        public int? ObjectCount { get; set; }
        public char? AlertStatus { get; set; }
        public bool Status { get; set; } = true;
        public DateTime RegDate { get; set; } = DateTime.Now;
    }

    public class Camera
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? cameraIP { get; set; }
        public string? Area { get; set; }
        public string? Location { get; set; }
        public string? Zone { get; set; }
        public int NVRId { get; set; }
        public int GroupId { get; set; }
        public string? Brand { get; set; }
        public string? Manufacture { get; set; }
        public string? MacAddress { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Unit { get; set; }
        public string? Standard { get; set; }
        public string? Profile { get; set; }
        public string? Protocol { get; set; }
        public int Port { get; set; }
        public int ChannelId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public DateTime? InstallationDate { get; set; }
        public DateTime? LastLive { get; set; }
        public string? rTSPURL { get; set; }
        public int PinCode { get; set; }
        public bool Status { get; set; } = true;
        public DateTime? UpdateDate { get; set; }
        public DateTime RegDate { get; set; } = DateTime.Now;
    }
}
