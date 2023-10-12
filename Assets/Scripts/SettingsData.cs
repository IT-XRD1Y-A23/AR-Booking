using System;
using UnityEngine;

[CreateAssetMenu]
public class SettingsData : ScriptableObject
{
    //use to create a Booking
    public string Group;
    public int GroupIndex;
    public int SelectedWorkStationNumber;
    public string SelectedWorkStationDescription;
    public DateTime Date; //not shown in unity inspector but works
    public string DateString; // same Date value just to show in unity
    public TimeSlot Timeslot;
}
