using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation
{
    private bool isBooked;
    public bool IsBooked
    {
        get { return isBooked; }
        set { isBooked = value; }
    }
    private string description;
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
}