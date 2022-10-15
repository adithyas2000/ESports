using Microsoft.AspNetCore.Mvc.Rendering;

namespace ESports.Models
{
    public class AddTrophyTeamViewModel
    {
        public Trophy trophy { get; set; }
        public IList<SelectListItem> teams { get; set; }

        public TrophyTeam trophyTeam { get; set; }
    }
}
