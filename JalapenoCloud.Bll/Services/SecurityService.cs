using System.Linq;
using JalapenoCloud.Common.Security;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Logic.Repositories;

namespace JalapenoCloud.Bll.Services
{
    public class SecurityService
    {
        private AdminRepository _adminRepository;

        public SecurityService()
        {
            _adminRepository = new AdminRepository();
        }

        public Admin CheckCredentials(string email, string password)
        {
            Admin admin = _adminRepository.GetByFilter(new { Email = email }).FirstOrDefault();

            if (admin == null)
                return null;

            bool passwordIsValid = PasswordHelper.CheckPassword(admin.Password, admin.PasswordSalt, password);

            return passwordIsValid ? admin : null;
        }
    }
}