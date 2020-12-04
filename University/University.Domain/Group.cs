namespace University.Domain
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Group
    {
        public virtual int Id { get; protected set; }

        public virtual string Name { get; protected set; }

        [JsonIgnore]
        public virtual ISet<Student> Students { get; protected set; } = new HashSet<Student>();

        [JsonIgnore]
        public virtual ISet<Teacher> Teachers { get; protected set; } = new HashSet<Teacher>();

        public override string ToString() => $"{this.Id} --> {this.Name}";
    }
}
