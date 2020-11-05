using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAssignmentPt2.Models
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "TIME")]
        [DisplayFormat(DataFormatString = "{0:mm\\:ss}", ApplyFormatInEditMode = true)]
        public TimeSpan Length { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Composer { get; set; }
        [ForeignKey("MusicCS")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
