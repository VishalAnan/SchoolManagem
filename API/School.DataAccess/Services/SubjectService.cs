using Microsoft.EntityFrameworkCore;
using School.DataAccess.Data;
using School.DataAccess.Repository;
using School.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.DataAccess.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly SchoolDbContext _context;
        private readonly IRepository<Subject> _subjectRepository;

        public SubjectService(IRepository<Subject> subjectRepository, SchoolDbContext context)
        {
            _context = context;
            _subjectRepository = subjectRepository;
        }

        // Get all subjects
        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _subjectRepository.GetAllAsync();
        }

        // Get a subject by ID
        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _subjectRepository.GetByIdAsync(id);
        }

        // Add a new subject
        public async Task AddSubjectAsync(Subject subject)
        {
            await _subjectRepository.AddAsync(subject);
        }

        // Update an existing subject
        public async Task UpdateSubjectAsync(Subject subject)
        {
            await _subjectRepository.UpdateAsync(subject);
        }

        // Delete a subject by ID
        public async Task DeleteSubjectAsync(int id)
        {
            await _subjectRepository.DeleteAsync(id);
        }
    }
}
