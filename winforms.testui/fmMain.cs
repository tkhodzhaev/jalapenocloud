using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using ComfortFramework.Core.Extenders;
using ComfortFramework.Core.Helpers;
using ComfortFramework.Core.Tools;
using JalapenoCloud.Bll.Services;
using JalapenoCloud.Common.Helpers;
using JalapenoCloud.Common.Messaging.Requests;
using JalapenoCloud.Common.Messaging.Responses;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Domain.Enums;
using Microsoft.IdentityModel.Tokens.JWT;
using NLog;

namespace TestUI
{
    public partial class fmMain : Form
    {
        private HttpClient _httpClient;
        private const string WebDomain = "https://jalapenoapi.jalapeno.su/AntispamService.svc";
        private const string LocalDomain = "http://localhost:33500";

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private string Domain
        {
            get
            {
                return chbProdServer.Checked ? WebDomain : LocalDomain;
            }
        }

        private string PublicKeyMethod
        {
            get
            {
                return String.Format("{0}/PublicKey", Domain);
            }
        }

        private string IsSpammerMethod
        {
            get
            {
                return String.Format("{0}/IsSpammer", Domain);
            }
        }

        private string RegisterClientMethod
        {
            get
            {
                return String.Format("{0}/RegisterClient", Domain);
            }
        }

        private string ComplainMethod
        {
            get
            {
                return String.Format("{0}/Complain", Domain);
            }
        }

        public fmMain()
        {
            InitializeComponent();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
            _httpClient = new HttpClient();
        }

        private void btnExecute1_Click(object sender, EventArgs e)
        {
            var rlog = new CFLogger(tbxResult, true);
            var olog = new CFLogger(tbxOutput, true);

            try
            {
                string request = PublicKeyMethod;
                string response = _httpClient.Get(request);

                rlog.WriteLine(response);
                rlog.WriteLine();
                rlog.WriteLine("------------------------");
                rlog.WriteLine();

                var objResponse = SerializationHelper.DeserializeFromJson<PublicKeyResponse>(response);

                rlog.WriteLine(objResponse.ToPrintString("\r\n\r\n"));
                olog.WriteLine("DONE.");
            }
            catch (Exception ex)
            {
                olog.WriteLine(ExceptionHelper.GetExceptionMessages(ex));
            }
        }

        private void btnExecute2_Click(object sender, EventArgs e)
        {
            var rlog = new CFLogger(tbxResult, true);
            var olog = new CFLogger(tbxOutput, true);

            try
            {
                var requestObj = new IsSpammerRequest()
                {
                    ClientId = Client(0).Id,
                    SenderId = tbxEditor.Text,
                    Hash = tbxEditor.Text + "_Hash"
                };

                string requestJson = requestObj.SerializeToJson();
                string requestString64 = EncodeRequest(requestJson);
                string response = _httpClient.Post(IsSpammerMethod, requestString64.SerializeToJson());

                rlog.WriteLine(response);
                rlog.WriteLine();
                rlog.WriteLine("------------------------");
                rlog.WriteLine();

                var objResponse = SerializationHelper.DeserializeFromJson<IsSpammerResponse>(response);

                rlog.WriteLine(objResponse.ToPrintString("\r\n\r\n"));
                olog.WriteLine("DONE.");
            }
            catch (Exception ex)
            {
                olog.WriteLine(ExceptionHelper.GetExceptionMessages(ex));
            }
        }

        private void btnExecute3_Click(object sender, EventArgs e)
        {
            var rlog = new CFLogger(tbxResult, true);
            var olog = new CFLogger(tbxOutput, true);

            try
            {
                //var service = new SettingService();
                //string uriTemplate = service.GetDbSetting<string>(DbSettingKey.TokenValidationUriTemplate);
                //string uri = uriTemplate.Parameters(tbxEditor.Text);

                //string json = _httpClient.Get(uri);
                //string googleId = JsonHelper.FindJProperty(json, "id");

                //rlog.WriteLine(json);
                //rlog.WriteLine(googleId);
                //rlog.WriteLine();
                //rlog.WriteLine("------------------------");
                //rlog.WriteLine();

                var requestObj = new RegisterClientRequest()
                {
                    ClientId = Guid.NewGuid(),
                    Token = tbxEditor.Text
                };

                string requestJson = requestObj.SerializeToJson();
                string requestString64 = EncodeRequest(requestJson);
                string response = _httpClient.Post(RegisterClientMethod, requestString64.SerializeToJson());

                rlog.WriteLine(response);
                rlog.WriteLine();
                rlog.WriteLine("------------------------");
                rlog.WriteLine();

                var objResponse = SerializationHelper.DeserializeFromJson<RegisterClientResponse>(response);

                rlog.WriteLine(objResponse.ToPrintString("\r\n\r\n"));
                olog.WriteLine("DONE.");
            }
            catch (Exception ex)
            {
                olog.WriteLine(ExceptionHelper.GetExceptionMessages(ex));
            }
        }

        private void btnExecute4_Click(object sender, EventArgs e)
        {
            var rlog = new CFLogger(tbxResult, true);
            var olog = new CFLogger(tbxOutput, true);

            try
            {
                var rnd = new Random(DateTime.UtcNow.Millisecond);

                var requestObj = new ComplainRequest()
                {
                    ClientId = Client(rnd.Next(0, 10)).Id,
                    SenderId = tbxEditor.Text,
                    Hash = tbxEditor.Text + "_Hash"
                };

                string requestJson = requestObj.SerializeToJson();
                string requestString64 = EncodeRequest(requestJson);
                string response = _httpClient.Post(ComplainMethod, requestString64.SerializeToJson());

                rlog.WriteLine(response);
                rlog.WriteLine();
                rlog.WriteLine("------------------------");
                rlog.WriteLine();

                var objResponse = SerializationHelper.DeserializeFromJson<ComplainResponse>(response);

                rlog.WriteLine(objResponse.ToPrintString("\r\n\r\n"));
                olog.WriteLine("DONE.");
            }
            catch (Exception ex)
            {
                olog.WriteLine(ExceptionHelper.GetExceptionMessages(ex));
            }
        }

        private void btnTests_Click(object sender, EventArgs e)
        {
            NotificationAndLogService.LogResponse("TEST Jalapeno Cloud response", Guid.NewGuid(), "Some Jalapeno API method", false);
            NotificationAndLogService.LogException(new Exception("TEST Jalapeno Cloud Exception"), Guid.NewGuid(), "Another Jalapeno API method");
        }

        private string EncodeRequest(string requestJson)
        {
            var settingService = new SettingService();
            int keySize = settingService.GetDbSetting<int>(DbSettingKey.KeySize);
            bool requestEncodingEnabled = settingService.GetDbSetting<bool>(DbSettingKey.RequestEncodingEnabled);

            if (requestEncodingEnabled)
            {
                using (var rsa = new RSACryptoServiceProvider(keySize))
                {
                    var objResponse = SerializationHelper.DeserializeFromJson<PublicKeyResponse>(_httpClient.Get(PublicKeyMethod));
                    string publicKey = objResponse.PublicKey;

                    //string publicKey = settingService.GetDbSetting<string>(DbSettingKey.PublicKey);

                    rsa.FromXmlString(publicKey);

                    byte[] data = StringHelper.GetBytes(requestJson);
                    byte[] encryptedData = rsa.Encrypt(data, false);

                    string encodedRequest = Convert.ToBase64String(encryptedData);
                    return encodedRequest;
                }
            }
            else
            {
                string encodedRequest = Convert.ToBase64String(StringHelper.GetBytes(requestJson));
                return encodedRequest;
            }
        }

        private Client Client(int index)
        {
            Client client = Clients()[index];
            return client;
        }

        private List<Client> Clients()
        {
            List<Client> clients = new ClientService().GetAll();
            return clients;
        }

        private void btnTestJWT_Click(object sender, EventArgs e)
        {
            //секретный Client ID веб сервиса
            string audience = "140853970719-4ohgmn0eojg2qeh75r96m9iojpra4omr.apps.googleusercontent.com";

            //секретный Client ID приложения

            string[] azp = "140853970719-u12i558l40p9gvngtgl93m7jbe5n95t4.apps.googleusercontent.com;140853970719-3qs4lat9gcsrsqio399qq7jdedn41q74.apps.googleusercontent.com".Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            var olog = new CFLogger(tbxOutput, true);

            string token = tbxEditor.Text;
            var tokenHandler = new JWTSecurityTokenHandler();
            SecurityToken tok = tokenHandler.ReadToken(token);
            var securityToken = tok as JWTSecurityToken;

            string serializedToken = tokenHandler.WriteToken(securityToken);
            olog.WriteLine("Прочитано");
            olog.WriteLine(serializedToken);

            var validationParameters =
                new TokenValidationParameters()
                {
                    AllowedAudience = audience,
                    ValidIssuer = "accounts.google.com",
                    ValidateExpiration = true,
                    ValidateSignature = false,
                };
            try
            {
                ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters);
                olog.WriteLine("валидировано");
                bool allGood = ValidateClaim(securityToken, "azp", azp) && ValidateClaim(securityToken, "aud", audience);

                var email = GetClaimValue(securityToken, "email");
                var userId = GetClaimValue(securityToken, "id");

                olog.WriteLine("emeil " + email + "  user id=" + userId + "  allGood=" + allGood);
            }
            catch (Exception ex)
            {
                olog.WriteLine("Не валидировано");
                olog.WriteLine(ex.Message);
            }
        }

        private bool ValidateClaim(JWTSecurityToken securityToken, string type, string value)
        {
            string claim = GetClaimValue(securityToken, type);

            if (claim == null)
            {
                return false;
            }

            return claim == value;
        }

        private bool ValidateClaim(JWTSecurityToken securityToken, string type, IEnumerable<string> values)
        {
            string claim = GetClaimValue(securityToken, type);
            if (claim == null)
                return false;

            return values.Contains(claim);
        }


        private string GetClaimValue(JWTSecurityToken securityToken, string type)
        {
            var claim = securityToken.Claims.SingleOrDefault(x => x.Type == type);
            if (claim == null)
            {
                return null;
            }

            return claim.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jwt = tbxEditor.Text;
            string email;
            string userIdByJwt = GoogleApiService.GetUserIdByJwt(jwt, out email);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var rlog = new CFLogger(tbxResult, true);
            var sw = new Stopwatch();
            string r =
                "Test log request The program '[2664] WebDev.WebServer40.EXE: Managed (v4.0.30319)' has exited with code 0 (0x0).";
            var ex = new Exception("Test Exception");
            sw.Start();

            for (int i = 1; i <= 1000; i++)
            {
                LogRequest(r, Guid.NewGuid(), "Test API method");
                LogException(ex, Guid.NewGuid(), "Test API method");
            }
            sw.Stop();
            rlog.WriteLine(sw.ElapsedMilliseconds);
            rlog.WriteLine("Done.");

            Stopwatch nlog = Stopwatch.StartNew();
            for (int i = 1; i <= 1000; i++)
            {
                LogNlog(ex, r);
            }
            nlog.Stop();
            rlog.WriteLine(nlog.ElapsedMilliseconds);
            rlog.WriteLine("Done nlog.");
        }

        public void LogNlog(Exception ex, string request)
        {
            Guid newGuid = Guid.NewGuid();
            _logger.Debug("Request ID: {0}\r\nDate: {1}\r\nAPI Method: {2}\r\nRequest: {3}\r\n\r\n", newGuid, DateTime.UtcNow, "Request namme", request);
            _logger.Error(string.Format("Request ID: {0}\r\nDate: {1}\r\nAPI Method: {2}", newGuid, DateTime.UtcNow, "Api method name"), ex);
        }
        public void LogException(Exception ex, Guid requestId, string apiMethod)
        {
            string text = "Request ID: {0}\r\nDate: {1}\r\nAPI Method: {2}\r\nException: {3}\r\nStackTrace: {4}\r\n\r\n".Parameters(requestId, DateTime.UtcNow.ToString(), apiMethod, ex.Message, ex.StackTrace);
            Log(text);
        }

        private void LogRequest(string request, Guid requestId, string apiMethod)
        {
            string text = "Request ID: {0}\r\nDate: {1}\r\nAPI Method: {2}\r\nRequest: {3}\r\n\r\n".Parameters(requestId, DateTime.UtcNow.ToString(), apiMethod, request);
            Log(text);
        }

        private void Log(string text)
        {
            try
            {
                string logFolder = LogFolder();
                string logFile = DateTime.UtcNow.ToString("yyyy-MM-dd") + ".log.txt";
                string path = Path.Combine(logFolder, logFile);

                if (!File.Exists(path))
                    File.Create(path).Dispose();

                File.AppendAllText(path, text, Encoding.UTF8);
            }
            catch { }
        }

        private string LogFolder()
        {
            return @"c:\Test\";
        }
    }
}