using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESports.Models
{
    public class PlayersBid
    {
        [Key, Column(Order = 0)]
        public int TrophyID { get; set; }

        [Key, Column(Order = 1)]
        public string TeamId { get; set; }

        [Required]
       
        public int PlayerId { get; set; }

        [Required]
        [DisplayName("Sold Price")]
        public int BidAmount { get; set; }
    }
}
