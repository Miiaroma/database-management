﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonDB.Models
{
    public partial class Phone
    {
        public Phone()
        {
        }

        public Phone(string type, string number)
        {
            Type = type;
            Number = number;
        }     
        
        public long Id { get; set; }
        public string Type { get; set; }
        [StringLength(50)]
        public string Number { get; set; }
        public long? PersonId { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("Phone")]
        public virtual Person Person { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{Type}\t{Number}";
        }        
    }
}