using System;
using System.Data;
using System.Linq;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic;
using JalapenoCloud.Dal.Logic.Repositories;
using ServiceStack.OrmLite;

namespace JalapenoCloud.DbDeployer
{
    public class DbDeployer
    {
        public void Deploy()
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                Type[] dropListOrdered = DropListOrdered();
                Type[] createListOrdered = CreateListOrdered();

                db.DropTables(dropListOrdered);
                db.CreateTables(true, createListOrdered);
            }
        }

        public void PostDeployment(string folderContainingScripts)
        {
            var ssExecutor = new SqlScriptExecutor();
            ssExecutor.ExecuteAllScriptsInFolder(folderContainingScripts);
        }

        public void DeployTestData()
        {
            var userRepository = new UserRepository();
            var clientRepository = new ClientRepository();
            var spammerRepository = new SpammerRepository();
            var complaintRepository = new ComplaintRepository();

            for (int i = 1; i <= 50; i++)
            {
                var user = new User()
                {
                    GoogleId = "User " + i.ToString(),
                    RegistrationDate = DateTime.UtcNow,
                    UnlimitedAccess = true,
                    PaymentInfo = null,
                    PaymentDate = null,
                    Paid = false,
                    Email = null
                };

                userRepository.Save(user);

                for (int j = 1; j <= 2; j++)
                {
                    var client = new Client()
                    {
                        RegistrationDate = DateTime.UtcNow,
                        UserId = user.Id
                    };

                    clientRepository.Save(client);
                }

                var spammer = new Spammer()
                {
                    SenderId = "SenderId-" + i.ToString(),
                    RegistrationDate = DateTime.UtcNow,
                    TotalComplaints = 1
                };

                spammerRepository.Save(spammer);

                var complaint = new Complaint()
                {
                    Date = DateTime.UtcNow,
                    SpammerId = spammer.Id,
                    SmsHash = spammer.Id.ToString(),
                    UserId = user.Id
                };

                complaintRepository.Save(complaint);
            }
        }

        private Type[] DropListOrdered()
        {
            Type[] response = CreateListOrdered().Reverse().ToArray();
            return response;
        }

        private Type[] CreateListOrdered()
        {
            Type[] response = new Type[]
                {
                    typeof(Admin),
                    typeof(Setting),
                    typeof(User),
                    typeof(SmsHash),
                    typeof(Spammer),
                    typeof(Client),
                    typeof(Complaint),
                    typeof(ExceptionLog)
                };

            return response;
        }
    }
}