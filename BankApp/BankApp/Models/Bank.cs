using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models
{
    public partial class Bank
    {
        public Bank()
        {
            Account = new HashSet<Account>();
            Customer = new HashSet<Customer>();
        }

        public Bank(string name, string bic)
        {
            Name = name;
            Bic = bic;
        }

        public long ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("BIC")]
        [StringLength(10)]
        public string Bic { get; set; }

        [InverseProperty("Bank")]
        public virtual ICollection<Account> Account { get; set; }
        [InverseProperty("Bank")]
        public virtual ICollection<Customer> Customer { get; set; }

        public override string ToString()
        {
            return $"{ID},{Name},{Bic}";
        }
    }   
}