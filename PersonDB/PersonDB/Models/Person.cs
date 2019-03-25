using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonDB.Models
{
    public partial class Person
    {
        public Person()
        {
            Phone = new HashSet<Phone>();
        }

        public Person(string name, short? age)
        {
            Name = name;
            Age = age;
            Phone = new HashSet<Phone>();
        }

        public Person(string name, short? age, ICollection<Phone> phone)
        {
            Name = name;
            Age = age;
            Phone = phone;
        }

        public long Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public short? Age { get; set; }

        [InverseProperty("Person")]
        public virtual ICollection<Phone> Phone { get; set; }

        public override string ToString()
        {
            string retValue = $"{Name}, {Age} ";
            return retValue;
        }

        public string ShowData()
        {
            return $"{Id}, {Name}, {Age}";
        }
    }
}