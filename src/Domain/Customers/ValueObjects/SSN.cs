// <copyright file="SSN.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers.ValueObjects
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// SSN <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">Entity Design Pattern</see>.
    /// </summary>
    public readonly struct SSN
    {
        private const string RegExForValidation = @"^\d{6,8}[-|(\s)]{0,1}\d{4}$";

        private readonly string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="SSN"/> struct.
        /// </summary>
        /// <param name="text">SSN.</param>
        public SSN(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new SSNShouldNotBeEmptyException($"The {nameof(text)} field is required.");
            }

            Regex regex = new Regex(RegExForValidation);
            Match match = regex.Match(text);

            if (!match.Success)
            {
                throw new InvalidSSNException($"Invalid {nameof(text)} format. Use YYMMDDNNNN.");
            }

            this.text = text;
        }

        /// <summary>
        /// Converts into string.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString() => this.text;

        public override bool Equals(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }

        public static bool operator ==(SSN left, SSN right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SSN left, SSN right)
        {
            return !(left == right);
        }
    }
}
