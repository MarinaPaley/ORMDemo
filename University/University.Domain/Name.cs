namespace University.Domain
{
    using System;
    using Infrastructure.Extensions;

    public class Name
    {
        public virtual string FirstName { get; protected set; }

        public virtual string LastName { get; protected set; }

        public virtual string MiddleName { get; protected set; }

        [Obsolete("For NHibernate only.", true)]
        protected Name()
        {
        }

        public Name(string firstName, string lastName, string middleName)
        {
            this.FirstName = firstName.NullIfNullOrWhitespace()
                ?? throw new ArgumentOutOfRangeException(nameof(firstName));

            this.LastName = lastName.NullIfNullOrWhitespace()
                ?? throw new ArgumentOutOfRangeException(nameof(lastName));

            //if (!(middleName?.Trim().Any() ?? true))
            //{
            //    throw new ArgumentOutOfRangeException(nameof(middleName));
            //}

            if (middleName != null && string.IsNullOrWhiteSpace(middleName))
            {
                throw new ArgumentOutOfRangeException(nameof(middleName));
            }

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
