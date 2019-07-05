namespace AdvicentChallenge.Models
{
    public sealed class CollegeModel
    {
        public string Name { get; set; }
        public decimal? InStateTuition { get; set; }
        public decimal? OutOfStateTuition { get; set; }
        public decimal? RoomAndBoard { get; set; }
    }
}