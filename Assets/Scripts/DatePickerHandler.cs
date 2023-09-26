using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class DatePickerHandler : MonoBehaviour
{

    // Start is called before the first frame update
  public void SelectDate(DateTime date)
    {
       int selected= date.Day;
       Debug.Log(selected);
    }

}