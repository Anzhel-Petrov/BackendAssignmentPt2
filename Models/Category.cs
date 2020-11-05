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
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string CategoryName { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public  ICollection<Product> Products { get; set; }
    }
}
