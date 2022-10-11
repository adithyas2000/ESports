using System.ComponentModel.DataAnnotations;

namespace ESports.Models
{
    public class Player
    {
        [Key]
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