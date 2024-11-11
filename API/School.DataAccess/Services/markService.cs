using Microsoft.EntityFrameworkCore;
using School.DataAccess.Data;
using School.DataAccess.Repository;
using School.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Services
{
    public class MarkService : ImarkService
    {
        private readonly SchoolDbContext _context;
        private readonly IRepository<Mark> _markRepository;

        public MarkService(IRepository<Mark> markRepository, SchoolDbContext context)
        {
            _context = context;
            _markRepository = markRepository;
        }

        public async Task<IEnumerable<Mark>> GetAllMarksAsync()
        {
            return await _markRepository.GetAllAsync();
        }

        public async Task<Mark> GetMarkByIdAsync(int id)
        {
            return await _markRepository.GetByIdAsync(id);
        }

        public async Task AddMarkAsync(Mark mark)
        {
            await _markRepository.AddAsync(mark);
        }

        public async Task UpdateMarkAsync(Mark mark)
        {
            await _markRepository.UpdateAsync(mark);
        }

        public async Task DeleteMarkAsync(int id)
        {
            await _markRepository.DeleteAsync(id);
        }
       

    }

}
