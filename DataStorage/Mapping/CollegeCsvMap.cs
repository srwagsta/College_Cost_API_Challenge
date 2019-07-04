using AdvicentChallenge.Models;
using CsvHelper.Configuration;

namespace AdvicentChallenge.DataStorage.Mapping
{
    public sealed class CollegeCsvMap : ClassMap<CollegeModel>
    {
        public CollegeCsvMap()
        {
            Map(m => m.Name).Name("College", "Name");
            Map(m => m.InStateTuition).Name("Tuition (in-state)", "InStateTuition");
            Map(m => m.OutOfStateTuition).Name("Tuition (out-of-state)", "OutOfStateTuition");
            Map(m => m.RoomAndBoard).Name("Room & Board", "RoomAndBoard");
        }
    }
}