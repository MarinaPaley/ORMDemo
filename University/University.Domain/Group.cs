namespace University.Domain
{
    using System.Collections.Generic;

    public class Group
    {
        public virtual int Id { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual ISet<Student> Students { get; protected set; } = new HashSet<Student>();

        public virtual ISet<Teacher> Teachers { get; protected set; } = new HashSet<Teacher>();

        public override string ToString() => $"{this.Id} --> {this.Name}";
    }
}
