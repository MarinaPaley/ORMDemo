using System;
using System.Collections.Generic;
using System.Linq;
using University.Domain;
using University.NH.Repositories;

namespace University.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        private readonly ITeacherRepository teacherRepository;

        public StudentService(IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            this.studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            this.teacherRepository = teacherRepository ?? throw new ArgumentNullException(nameof(teacherRepository));
        }

        public List<Student> GetAll()
        {
            return this.studentRepository.GetAll().ToList();
        }

        public List<Teacher> GetTeachersByStudentId(int id)
        {
            if (!this.studentRepository.TryGet(id, out var student))
            {
                return new List<Teacher>();
            }

            return this.teacherRepository.Filter(t => t.Groups.Contains(student.Group)).ToList();
        }
    }
}
