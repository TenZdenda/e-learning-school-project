using ProjectSchool.Interface;
using ProjectSchool.Migrations;
using ProjectSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool.Services.EFServices
{
    public class EFAdminService: IAdminService
    {
        ProjectSchoolDbContextModelSnapshot context;

        //public EFAdminService(ProjectSchoolDbContextModelSnapshot service)
        //{
        //    context = service;
        //}

        public void AddAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void DeleteAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Admin> GetAdmins()
        {
            return null;
        }
    }
}
