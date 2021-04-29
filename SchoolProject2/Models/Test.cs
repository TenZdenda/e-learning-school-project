using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Models
{
    public class Test
    {
        public int Id { get; set; }

        public string TestName { get; set; }

        public int Duration { get; set; }

        public DateTime StartTime { get; set; }

        public int NumOfQuestions { get; set; }

        
        public int TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public virtual TeacherUser TeacherUser { get; set; }

        public int AdminId { get; set; }
        [ForeignKey(nameof(AdminId))]
        public virtual AdminUser AdminUser { get; set; }
        
    }
}
