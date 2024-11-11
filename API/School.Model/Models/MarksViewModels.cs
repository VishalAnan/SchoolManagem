using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model.Models
{
    public class MarksViewModels
    {
        public int MarkId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Score { get; set; }
    }
}
