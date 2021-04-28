using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool.Models
{
    public class Admin
    {
        
        public int AdminId { get; set; }


        public string Name { get; set; }


        public string RoadNameAndNumber { get; set; }


        public string AreaCodeAndTown { get; set; }


        public string EmailAddress { get; set; }


        public string PhoneNumber { get; set; }

        

        [ForeignKey("Test")]
        public int TestId { get; set; }

        

        [ForeignKey("Teacher")]
        public string TeacherId { get; set; }


        public string UserName { get; set; }


        public string Password { get; set; }

    }
}
