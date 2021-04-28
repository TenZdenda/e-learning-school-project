﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [ForeignKey("Admin")]

        public int AdminId { get; set; }


        public string Name { get; set; }


        public string RoadNameAndNumber { get; set; }


        public string AreaCodeAndTown { get; set; }


        public string EmailAddress { get; set; }


        public string PhoneNumber { get; set; }


        public string UserName { get; set; }


        public string Password { get; set; }


        //public void PrepareTestPaper()
        //{

        //}

        //public void ModifyTestPaper()
        //{

        //}

        //public void DeclareResult()
        //{

        //}

    }
}
