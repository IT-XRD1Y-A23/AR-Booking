using System;

public class Booking
{
    public int workstationNumber;
    public DateTime bookedDate;
    public int timeslot;
    public string groupNumber; 


    public Booking(int workstationNumber,DateTime bookedDate,  int timeslot, string groupNumber)
    {
        this.workstationNumber = workstationNumber;
        this.bookedDate = bookedDate;
        this.timeslot = timeslot;
        this.groupNumber = groupNumber;
    }

}

