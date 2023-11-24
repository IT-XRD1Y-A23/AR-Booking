using System;
using JetBrains.Annotations;
using UnityEngine;

public class Booking
{
    [CanBeNull] public string id;
    public string workstationNumber;
    public DateTime bookedDate;
    public TimeSlot timeslot;
    public string groupNumber; 


    public Booking(string workstationNumber,DateTime bookedDate,  TimeSlot timeslot, string groupNumber)
    {
        this.workstationNumber = workstationNumber;
        this.bookedDate = bookedDate;
        this.timeslot = timeslot;
        this.groupNumber = groupNumber;
    }
    
    public Booking(string workstationNumber,DateTime bookedDate, TimeSlot timeslot, string groupNumber, string id)
    {
        this.workstationNumber = workstationNumber;
        this.bookedDate = bookedDate;
        this.timeslot = timeslot;
        this.groupNumber = groupNumber;
        this.id = id;
    }

}

