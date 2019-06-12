using System;
using System.Collections.Generic;
using JalapenoCloud.Bll.Services;
using UI.BaseClasses;

namespace UI
{
    public partial class Statistics : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CheckUserRights();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                Bind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            var service = new StatisticsService(tpdRange.Start, tpdRange.End);

            long totalClients = service.TotalClients();
            long totalComplaints = service.TotalComplaints();
            long totalExceptions = service.TotalExceptions();
            long totalSmsHashes = service.TotalSmsHashes();
            long totalSpammers = service.TotalSpammers();
            long totalUsers = service.TotalUsers();
            long totalPaidUsers = service.TotalUsers(true);

            var items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("Clients", totalClients.ToString()));
            items.Add(new KeyValuePair<string, string>("Complaints", totalComplaints.ToString()));
            items.Add(new KeyValuePair<string, string>("Exceptions", totalExceptions.ToString()));
            items.Add(new KeyValuePair<string, string>("SMS Hashes", totalSmsHashes.ToString()));
            items.Add(new KeyValuePair<string, string>("Spammers", totalSpammers.ToString()));
            items.Add(new KeyValuePair<string, string>("Users", totalUsers.ToString()));
            items.Add(new KeyValuePair<string, string>("Paid Users", totalPaidUsers.ToString()));

            rptData.DataSource = items;
            rptData.DataBind();
        }
    }
}