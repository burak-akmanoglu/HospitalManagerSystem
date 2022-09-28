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
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        [ForeignKey("Building")]
        public int? BuildingId { get; set; }
        public virtual Building Building { get; set; }
        
    }

}
