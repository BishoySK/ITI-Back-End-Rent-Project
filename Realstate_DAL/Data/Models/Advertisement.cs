
using System.ComponentModel.DataAnnotations.Schema;

namespace Realstate_DAL;

    public class Advertisement
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public string Type { get; set; } = "";
        public string Location { get; set; } = "";
        public string City { get; set; } = "";
        public int No_Of_Rooms { get; set; }
        public int No_Of_Bathrooms { get; set; }
        public int Floor_Number { get; set; }
        public bool IsFurnished { get; set; }
        public string ImgUrl { get; set; } = "";
         [ForeignKey("Company")]
        public Guid Company_Id { get; set; }
        [ForeignKey("UserClass")]
        public Guid user_Id { get; set; }
        public DateTime? AdvDate { get; set; }
        public UserClass? UserClass { get; set; }
        public Company? company { get; set; }  





    }

