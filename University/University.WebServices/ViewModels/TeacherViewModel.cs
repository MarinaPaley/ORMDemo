namespace University.WebServices.ViewModels
{
    using System;
    using University.Domain;

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
