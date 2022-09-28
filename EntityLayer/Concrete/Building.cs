using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }

        [JsonIgnore]
        public List<Room> Rooms { get; set; }
        [JsonIgnore]
        public List<Storehouse> Storehouses { get; set; }
       
    }
}
