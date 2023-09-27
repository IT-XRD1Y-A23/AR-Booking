using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using TMPro;
public class DatePickerHandler : MonoBehaviour
{
    public TextMeshProUGUI dateLabel;
    // Start is called before the first frame update
  public void SelectDate(DateTime date)
    {
       string selected= date.ToString("ddd, dd MMM");
       dateLabel.text=selected;
    }

}