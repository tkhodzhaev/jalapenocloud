using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using ComfortFramework.Core.Extenders;

namespace UI.Controls
{
    public partial class UserMessage : System.Web.UI.UserControl
    {
        public enum MessageType
        {
            [Description("alert alert-info")]
            Info = 0,

            [Description("alert alert-success")]
            Success = 1,

            [Description("alert alert-block")]
            Warning = 2,

            [Description("alert alert-error")]
            Error = 3
        }

        private readonly int _minFloatingMessageDisplayTime = 500;
        private List<KeyValuePair<string, MessageType>> _messages = new List<KeyValuePair<string, MessageType>>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region Floating messages

        public void ShowFloatingMessage(string message, Color color, int time, bool applyErrorStyle)
        {
            if (time < _minFloatingMessageDisplayTime)
                time = _minFloatingMessageDisplayTime;

            string classname = applyErrorStyle ? "ui-state-error" : "";
            string key = message + color.Name + time.ToString() + applyErrorStyle.ToString();
            string script = string.Format("showmessage(\"{0}\", {1}, \"{2}\", \"{3}\");", message, time, color.Name, classname);

            Page.ClientScript.RegisterStartupScript(this.GetType(), key, script, true);
        }

        public void ShowFloatingMessagesLine(List<KeyValuePair<string, Color>> messages, int time, bool applyErrorStyle, int timeInc = 0)
        {
            if (messages == null)
                return;

            foreach (KeyValuePair<string, Color> message in messages)
            {
                ShowFloatingMessage(message.Key, message.Value, time, applyErrorStyle);
                time += timeInc;
            }
        }

        #endregion Floating messages

        #region Static messages

        public void AddStaticMessageToLine(string message, MessageType messageType)
        {
            _messages.Add(new KeyValuePair<string, MessageType>(message, messageType));
            ShowStaticMessagesLine(_messages);
        }

        public void ShowStaticMessagesLine(List<KeyValuePair<string, MessageType>> messages)
        {
            if (messages == null || messages.Count == 0)
                return;

            List<KeyValuePair<string, string>> items = messages
                .Select(c => new KeyValuePair<string, string>(c.Key, c.Value.GetFieldDescription()))
                .ToList();

            rptStaticMessages.Visible = true;
            rptStaticMessages.DataSource = items;
            rptStaticMessages.DataBind();
        }

        public void HideStaticMessagesLine()
        {
            rptStaticMessages.Visible = false;
            rptStaticMessages.DataSource = null;
            rptStaticMessages.DataBind();
        }

        #endregion Static messages
    }
}