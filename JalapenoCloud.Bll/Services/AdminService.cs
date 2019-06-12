using System;
using JalapenoCloud.Bll.Base;
using JalapenoCloud.Common.Security;
using JalapenoCloud.Dal.Domain.Entities;

namespace JalapenoCloud.Bll.Services
{
    public class AdminService : ServiceBase<Admin>
    {
        public AdminService()
            : base()
        {
        }

        public void Add(string email, string name, string password)
        {
            string salt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.EncodePassword(password, salt);

            var admin = new Admin()
            {
                Email = email,
                Name = name,
                Password = passwordHash,
                PasswordSalt = salt
            };

            Save(admin);
        }

        public void ChangePassword(Guid id, string newPassword)
        {
            var admin = GetById(id);

            if (admin == null)
                throw new Exception("Unknown Id.");

            string salt = PasswordHelper.GenerateSalt();
            string newPasswordHash = PasswordHelper.EncodePassword(newPassword, salt);

            admin.Password = newPasswordHash;
            admin.PasswordSalt = salt;

            Save(admin);
        }
    }
}