using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Storehouse
    {
        [Key]
        public int StorehouseId { get; set; }
        public string StorehouseName { get; set; }
        [ForeignKey("Building")]
        
        public int? BuildingId { get; set; }
        public virtual Building Building { get; set; }

        [JsonIgnore]
        public List<Product> Products { get; set; }

       
    }

}
