using School.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Services
{
     public interface ImarkService
    {
        Task<IEnumerable<Mark>> GetAllMarksAsync();
        Task<Mark> GetMarkByIdAsync(int id);
        Task AddMarkAsync(Mark mark);
        Task UpdateMarkAsync(Mark mark);
        Task DeleteMarkAsync(int id);

       


    }
}
