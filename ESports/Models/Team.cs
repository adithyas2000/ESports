using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ESports.Models
{
    public class Team
    {
      
        public string Id { get; set; }


        [Required]
        [DisplayName("Team Name")]
        public string Name { get; set; }
    }
}
