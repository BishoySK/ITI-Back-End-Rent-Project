using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realstate_BL
{
    public class AdvWriteDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public string Type { get; set; } = "";
        public string Place { get; set; } = "";
        public string City { get; set; } = "";
        public int No_Of_Rooms { get; set; }
        public int No_Of_Bathrooms { get; set; }
        public int Floor_Number { get; set; }
        public bool IsFurnished { get; set; }
        public string ImgUrl { get; set; } = "";
        public DateTime? AdvDate { get; set; }
    }
}
