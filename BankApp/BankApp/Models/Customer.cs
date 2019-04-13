using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Account = new HashSet<Account>();
        }

        public Customer(string firstName, string lastName)
        {
            Firstname = firstName;
            Lastname = lastName;
        }

        public long ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }
        public long BankID { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Customer")]
        public virtual Bank Bank { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Account> Account { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Firstname} {Lastname}";
        }
    }
}