namespace ORMDemo
{
    using System.Collections.Generic;

    public class Group
    {
        public virtual int Id { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual ISet<Student> Students { get; protected set; } = new HashSet<Student>();

        public override string ToString() => $"{this.Id} --> {this.Name}";
    }
}
