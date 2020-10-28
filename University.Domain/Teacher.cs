namespace University.Domain
{
    using System.Collections.Generic;

    public class Teacher
    {
        public virtual int Id { get; protected set; }

        public virtual Name Name { get; protected set; }

        public virtual ISet<Group> Groups { get; protected set; } = new HashSet<Group>();

        public override string ToString()
        {
            return $"{this.Id} --> {this.Name} [{string.Join(", ", this.Groups)}]";
        }
    }
}
