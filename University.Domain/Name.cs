namespace University.Domain
{
    using System;

    public class Name
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string MiddleName { get; }

        [Obsolete("For NHibernate only.")]
        protected Name()
        {
        }

        public Name(string firstName, string lastName, string middleName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentOutOfRangeException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentOutOfRangeException(nameof(lastName));
            }

            //if (!(middleName?.Trim().Any() ?? true))
            //{
            //    throw new ArgumentOutOfRangeException(nameof(middleName));
            //}

            if (middleName != null && string.IsNullOrWhiteSpace(middleName))
            {
                throw new ArgumentOutOfRangeException(nameof(middleName));
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(this.FirstName, this.LastName, this.MiddleName ?? string.Empty);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null))
            {
                return false;
            }

            if (object.ReferenceEquals(obj, this))
            {
                return true;
            }

            return obj is Name other
                   && string.Equals(this.FirstName, other.FirstName, StringComparison.InvariantCulture)
                   && string.Equals(this.LastName, other.LastName, StringComparison.InvariantCulture)
                   && string.Equals(this.MiddleName, other.MiddleName, StringComparison.InvariantCulture);
        }

        /// <inheritdoc />
        public override string ToString() => $"{this.LastName} {this.FirstName} {this.MiddleName}".Trim();
    }
}
