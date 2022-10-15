using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESports.Models
{
    public class TrophyTeam
    {

        [Key, Column(Order = 0)]
        public int TrophyID { get; set; }

        [Key, Column(Order = 1)]
        public string TeamId { get; set; }

        [Required]
        [DisplayName("Max Bidding Amount")]
        public int MaxPrice { get; set; }

        [Required]
        [DisplayName("Spent Amount")]
        public int SpentAmount { get; set; } = 0;

    }
}
