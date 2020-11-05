using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAssignmentPt2.Models
{
    public class Book : Product
    {
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Author { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Publisher { get; set; }
        [Required]
        [Column(TypeName = "SMALLINT")]
        public short Published { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string ISBN { get; set; }
    }
}
