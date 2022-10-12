using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESports.Models
{
    public class TrophyRegistration
    {
        [Key,Column(Order=0)]
        public string TrophyID { get; set; }
        [Key,Column(Order =1)]
        public string PlayerNIC { get; set; }
        [Required]
        public string PlayerFName { get; set; }
        [Required]
        public string PlayerLName { get; set; }
        [Required]
        public int PlayerAge { get; set; }
        [Required]
        public string PlayerRole { get; set; }//Batsman/Baller/WK...
        [Required]
        public string PlayerHand { get; set; } //Left/Right handed
        [Required]
        public string CurrentTeam { get; set; } = "NULL";
    }
}
