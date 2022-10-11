using System.ComponentModel.DataAnnotations;

namespace ESports.Models
{
    public class TrophyRegistration
    {
        [Key]
        public string TrophyID { get; set; }
        [Required]
        public Player Player { get; set; }
    }
}
