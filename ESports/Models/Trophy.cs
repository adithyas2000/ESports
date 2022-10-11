using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ESports.Models
{
    public class Trophy
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [DisplayName("Trophy Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Event Venue")]
        public string Venue { get; set; }

        [Required]
        [DisplayName("Event Starting Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("Event Ending Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [DisplayName("Registration/Bidding Closing Date")]
        public DateTime ClosingDate { get; set; } 

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
