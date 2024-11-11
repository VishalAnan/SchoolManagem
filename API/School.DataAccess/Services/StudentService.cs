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
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Subject> _subjeRepository;
        private readonly SchoolDbContext _context;

        public StudentService(IRepository<Student> studentRepository, SchoolDbContext context, IRepository<Subject> subjeRepository)
        {
            _context = context;
            _studentRepository = studentRepository;
            _subjeRepository = subjeRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }
        public async Task<List<StudentRankViewModel>> GetRankedStudentsAsync()
        {
            var rankedStudents = await _context.Students
              .Select(s => new
              {
                  FullName = s.FirstName + " " + s.LastName,
                  Class = s.Class,
                  TotalScore = _context.Marks
                      .Where(m => m.StudentId == s.StudentId)
                      .Sum(m => m.Score)
              })
              .OrderByDescending(sr => sr.TotalScore)
              .ToListAsync();

            // Assign ranks
            int rank = 1;
            List<StudentRankViewModel> rankedResult = new List<StudentRankViewModel>();
            for (int i = 0; i < rankedStudents.Count; i++)
            {
                string rankSuffix = GetRankSuffix(rank);
                rankedResult.Add(new StudentRankViewModel
                {
                    FullName = rankedStudents[i].FullName,
                    Class = rankedStudents[i].Class,
                    TotalScore = rankedStudents[i].TotalScore,
                    Rank = $"{rank}{rankSuffix}"
                });

                // Increment rank
                rank++;
            }

            return rankedResult;
        }
        private string GetRankSuffix(int rank)
        {
            // Handle special cases for 11th, 12th, and 13th
            if (rank % 100 >= 11 && rank % 100 <= 13)
            {
                return "th";
            }

            // Determine the suffix based on the last digit of the rank
            int lastDigit = rank % 10;
            if (lastDigit == 1) return "st";
            if (lastDigit == 2) return "nd";
            if (lastDigit == 3) return "rd";
            return "th";
        }
        public async Task<List<MarksViewModels>> GetMarkStudentsAsync()
        {
            var result = await (from mark in _context.Marks
                                join student in _context.Students on mark.StudentId equals student.StudentId
                                join subject in _context.Subjects on mark.SubjectId equals subject.SubjectId
                                select new MarksViewModels
                                {
                                    MarkId = mark.MarkId,
                                    StudentId = mark.StudentId,
                                    StudentName = student.FirstName, // Ensure `FirstName` exists in your `Student` model
                                    SubjectId = mark.SubjectId,
                                    SubjectName = subject.Name, // Ensure `Name` exists in your `Subject` model
                                    Score = mark.Score
                                }).ToListAsync();

            return result;
        }

    }


}
