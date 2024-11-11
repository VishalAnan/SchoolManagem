using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model.Models
{
    public class Mark
    {
        public int MarkId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public Int32 Score { get; set; }

        //public Student Student { get; set; }
       // public Subject Subject { get; set; }
    }

}
