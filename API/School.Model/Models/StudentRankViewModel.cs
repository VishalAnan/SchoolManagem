using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model.Models
{
    public class StudentRankViewModel
    {
        public string FullName { get; set; }
        public string Class { get; set; }
        public int TotalScore { get; set; }

        public string Rank { get; set; }

    }
}
