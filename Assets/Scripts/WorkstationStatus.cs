using System.Collections.Generic;
using UnityEngine;

public enum Status
{
    Unavailable,
    Available,
    Selected
}

public static class WorkstationStatus
{
    private static readonly Dictionary<Status, Color> ColorHexMap = new Dictionary<Status, Color>
    {
        {Status.Available, Color.green},
        {Status.Unavailable, Color.red},
        {Status.Selected, Color.yellow}
    };
    public static Color ToColor(this Status color)
    {
        return ColorHexMap[color];
    }
}