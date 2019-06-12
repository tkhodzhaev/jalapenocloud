using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ComfortFramework.Core.Extenders;
using ComfortFramework.Core.MailService;
using JalapenoCloud.Common.Helpers;
using JalapenoCloud.Dal.Domain.Enums;

namespace JalapenoCloud.Bll.Services
{
    public static class NotificationAndLogService
    {
        public static void LogRequest(string request, Guid requestId, string apiMethod)
        {
            string text = "Request ID: {0}\r\nDate: {1}\r\nAPI Method: {2}\r\nRequest: {3}\r\n\r\n".Parameters(requestId, DateTime.UtcNow.ToString(), apiMethod, request);
            Log(text);
        }

        public static void LogMessage(string message)
        {
            string text = string.Format("Date: {0}\r\nMessage {1}\r\n\r\n",
                DateTime.UtcNow, message);
            Log(text);
        }

        public static void LogException(string message, Exception ex)
        {
            string text = string.Format("Date: {0}\r\nMessage {1}\r\nException: {2}\r\nStackTrace: {3}\r\n\r\n",
                DateTime.UtcNow, message, ExceptionHelper.GetExceptionMessages(ex), ex.StackTrace);
            Log(text);
        }

        public static void LogResponse(string response, Guid requestId, string apiMethod, bool wasSuccessful)
        {
            string text = "Request ID: {0}\r\nDate: {1}\r\nAPI Method: {2}\r\nResponse: {3}\r\n\r\n".Parameters(requestId, DateTime.UtcNow.ToString(), apiMethod, response);
            Log(text);

            if (!wasSuccessful)
                SendMail("Jalapeno Cloud Request Failure", text);
        }

        public static void LogException(Exception ex, Guid requestId, string apiMethod)
        {
            string text = "Request ID: {0}\r\nDate: {1}\r\nAPI Method: {2}\r\nException: {3}\r\nStackTrace: {4}\r\n\r\n".Parameters(requestId, DateTime.UtcNow.ToString(), apiMethod, ExceptionHelper.GetExceptionMessages(ex), ex.StackTrace);
            Log(text);
            SendMail("Jalapeno Cloud Exception", text);
        }

        private static void SendMail(string subject, string body)
        {
            try
            {
                string logFolder = LogFolder();

                string mailSettingsPath = Path.Combine(logFolder, "mailsettings.mst");
                string mailSettingsString = File.ReadAllText(mailSettingsPath);
                string[] mailSettingsItems = mailSettingsString.Split(',');

                var mailSettings = new MailSettings()
                {
                    AsyncMode = false,
                    Attempts = 3,
                    EnableSsl = bool.Parse(mailSettingsItems[0]),
                    From = mailSettingsItems[1],
                    IsHtml = false,
                    SmtpLogin = mailSettingsItems[2],
                    SmtpPassword = mailSettingsItems[3],
                    SmtpPort = int.Parse(mailSettingsItems[4]),
                    SmtpServer = mailSettingsItems[5],
                    Timeout = int.Parse(mailSettingsItems[6])
                };

                string sendlistPath = Path.Combine(logFolder, "sendlist.mst");
                string sendlistString = File.ReadAllText(sendlistPath);
                List<string> sendlist = sendlistString.Split(',').ToList();

                var sender = new MailSender(mailSettings);
                sender.SendToMailingList(sendlist, subject, body);
            }
            catch { }
        }

        private static void Log(string text)
        {
            try
            {
                string logFolder = LogFolder();
                string logFile = DateTime.UtcNow.ToString("yyyy-MM-dd") + ".log.txt";
                string path = Path.Combine(logFolder, logFile);

                if (!File.Exists(path))
                    File.Create(path).Dispose();

                File.AppendAllText(path, text, ConstantContainer.Encoding);
            }
            catch { }
        }

        private static string LogFolder()
        {
            var service = new SettingService();
            string logFolder = service.GetDbSetting<string>(DbSettingKey.LogFolder);

            if (!Directory.Exists(logFolder))
                Directory.CreateDirectory(logFolder);

            return logFolder;
        }
    }
}