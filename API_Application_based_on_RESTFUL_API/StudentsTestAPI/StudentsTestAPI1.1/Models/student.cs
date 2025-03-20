using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentsTestAPI1._1.Models
{
    public partial class student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; } = null!;
        public string? Name { get; set; }
        public long? Age { get; set; }
    }
}
