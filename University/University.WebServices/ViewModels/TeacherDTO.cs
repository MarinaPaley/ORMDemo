using System;
using University.Domain;

namespace University.WebServices.ViewModels
{
    public class TeacherDTO
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }

    public class TeacherViewModel
    {
        public string FullName { get; }

        public TeacherViewModel(Name name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.FullName = name.FullName;
        }
    }
}
