using System;
using UnityEngine;

[CreateAssetMenu]
public class SettingsData : ScriptableObject
{
    //use to create a Booking
    public string Group;
    public int GroupIndex;
    public int WorkStationNumber;
    public DateTime Date;
    public TimeSlot TimeSlot;
}
