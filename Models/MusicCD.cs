using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAssignmentPt2.Models
{
    public class MusicCD : Product
    {
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Artist { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Label { get; set; }
        [Required]
        [Column(TypeName = "SMALLINT")]
        public short CDReleased { get; set; }
    }
}
