using System;

namespace SlayedLifeCore.Users
{
	public class UserSchedule
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int? DayOfWeekId { get; set; }
		public DateTime? SpecificDate { get; set; }
		public int StartHour { get; set; }
		public int StartMinute { get; set; }
		public int ClosedHour { get; set; }
		public int ClosedMinute { get; set; }
		public bool Deleted { get; set; }
		public bool Closed { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
