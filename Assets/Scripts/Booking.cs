using UnityEngine;
using System;

public class Booking 
{
    private int workstationNumber;
    public int  WorkStationNumber
    {
        get { return workstationNumber; }
        set { workstationNumber = value; }
    }
    private DateTime date;
    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }
    private TimeSlot timeSlot;
    public TimeSlot TimeSlot
    {
        get { return timeSlot; }
        set { timeSlot = value; }
    }
    private string groupNumber;
    public string GroupNumber
    {
        get { return groupNumber; }
        set { groupNumber = value; }
    }
}
