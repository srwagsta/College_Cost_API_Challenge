using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace AdvicentChallenge.Models
{
    public enum CollegeDataFields
    {
        Default,
        All,
        Name,
        inStateTuition,
        outOfStateTuition,
        inStateTotalCost,
        outOfStateTotalCost,
        roomAndBoard
    }
    public class CollegeDataRequestDto
    {
        public CollegeDataRequestDto()
        {
            this.roomAndBoard = true;
            this.dataFields = new[] {CollegeDataFields.Default};
        }

        public string collegeName { get; set; }
        public bool roomAndBoard { get; set; }
        public CollegeDataFields[] dataFields { get; set; }
    }
}