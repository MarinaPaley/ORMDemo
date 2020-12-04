namespace University.Domain
{
    public class Student
    {
        public virtual int Id { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual Group Group { get; protected set; }

        public override string ToString() => $"{this.Id} --> {this.Name} [{this.Group?.Name}]";
    }
}