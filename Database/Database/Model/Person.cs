using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Model
{
    public partial class Person
    {
        public long ID { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }
        [StringLength(10)]
        public string Sex { get; set; }
        [StringLength(10)]
        public string EyeColor { get; set; }
        public int? ShoeSize { get; set; }
        public int? Height { get; set; }
    }
}