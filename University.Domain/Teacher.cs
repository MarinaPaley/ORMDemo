namespace University.Domain
{
    using Infrastructure.Extensions;
    using System.Collections.Generic;

    public class Teacher
    {
        public virtual int Id { get; protected set; }

        public virtual Name Name { get; protected set; }

        public virtual ISet<Group> Groups { get; protected set; } = new HashSet<Group>();

        public override string ToString() => $"{this.Id} --> {this.Name} [{this.Groups.Join()}]";
    }
}
