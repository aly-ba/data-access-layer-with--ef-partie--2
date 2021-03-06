//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainReservation
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedule
    {
        public Schedule()
        {
            this.Reservations = new HashSet<Reservation>();
        }
    
        public int ScheduleId { get; set; }
        public int TrainId { get; set; }
        public System.DateTime ArrivalDate { get; set; }
        public System.DateTime DepartureDate { get; set; }
        public string LeavesFrom { get; set; }
        public string ArrivesAt { get; set; }
    
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual Train Train { get; set; }
    }
	public partial class Schedule : IValidate
	{
		public void Validate(ChangeAction action)
		{
			if (action == ChangeAction.Insert)
			{
				if (ArrivalDate < DepartureDate)
				{
					throw new InvalidOperationException(
							  "Arrival date cannot be before departure date");
				}

				if (LeavesFrom == ArrivesAt)
				{
					throw new InvalidOperationException(
							  "Can't leave from and arrive at the same location");
				}
			}
		}
	}
}
