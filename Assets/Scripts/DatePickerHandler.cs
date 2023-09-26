using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DatePickerHandler : MonoBehaviour
{

  public DatePicker datePicker;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(datePicker.Config.currentDate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
