using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers.Models
{
    public class Customer
    {
        public string CustomerId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Customer(string custumerId, string firstName, string lastName, string email)
        {
            CustomerId = custumerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public override string ToString() => $"{CustomerId} : {FirstName} {LastName}";
    }
}
