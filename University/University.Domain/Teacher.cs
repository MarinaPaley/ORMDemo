namespace University.Domain
{
    using Infrastructure.Extensions;
    using System;
    using System.Collections.Generic;

    public class Teacher
    {
        public virtual int Id { get; protected set; }

        public virtual Name Name { get; protected set; }

        public virtual ISet<Group> Groups { get; protected set; } = new HashSet<Group>();

        public override string ToString() => $"{this.Id} --> {this.Name} [{this.Groups.Join()}]";

        [Obsolete("Конструктор только для ORM")]
        protected Teacher() { }

        public Teacher(string lastName, string firstName, string middleName)
        {
            this.Name = new Name(firstName, lastName, middleName);
        }
    }
}
