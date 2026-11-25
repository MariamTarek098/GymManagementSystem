namespace GymManagementSystem.Entities
{
    public class Membership:BaseEntity

    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Member Member { get; set; } = default!;

        public int MemberId { get; set; }
        public Plan Paln { get; set; } = default!;

        public int PlanId { get; set; }


        public string Status => StartDate > DateTime.Now? "UpComing": "Active";


    }
}
