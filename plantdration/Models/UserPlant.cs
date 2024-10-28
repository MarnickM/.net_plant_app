using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plantdration.Models
{
    public class UserPlant
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlantId { get; set; }
        public DateTime DateAssigned { get; set; }
    }
}
