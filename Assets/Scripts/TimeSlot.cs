using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeSlot {
    Morning,
    Afternoon,
    Evening
}

public static class TimeSlots
{
    private static readonly Dictionary<string, TimeSlot> keyValuePairs = new Dictionary<string, TimeSlot>
    {
        {"08:00-12:00", TimeSlot.Morning},
        {"12:00-16:00", TimeSlot.Afternoon},
        {"16:00-00:00", TimeSlot.Evening}
    };
    public static TimeSlot ToTimeSlot(this string timeslot)
    {
        return keyValuePairs[timeslot];
    }

    public static string ToString(this TimeSlot timeslot)
    {
        switch (timeslot)
        {
            case TimeSlot.Morning:
                return "08:00-12:00";
                break;
            case TimeSlot.Afternoon:
                return "12:00-16:00";
                break;
            case TimeSlot.Evening:
                return "16:00-00:00";
                break;
            default:
                return "";
                break;
        }
    }
}