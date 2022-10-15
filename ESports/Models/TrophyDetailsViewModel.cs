namespace ESports.Models
{
    public class TrophyDetailsViewModel
    {
        public Trophy trophy { get; set; }
        public IList<TrophyRegistration> registrations { get; set; }

        public int bidValue { get; set; }
        public String team { get; set; }
        public string playerNIC { get; set; }
        public int trophyId { get; set; }
    }
}
    