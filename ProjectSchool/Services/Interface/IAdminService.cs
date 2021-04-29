using ProjectSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool.Interface
{
    public interface IAdminService
    {
        IEnumerable<Admin> GetAdmins();
        void AddAdmin(Admin admin);
        void DeleteAdmin(Admin admin);

    }
}
