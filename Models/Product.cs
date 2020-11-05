using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendAssignmentPt2.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string ImageFileName { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Track> Tracks { get; set; }
        public Product()
        {

        }
    }
}
