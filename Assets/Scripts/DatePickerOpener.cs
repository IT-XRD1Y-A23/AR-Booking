using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatePickerOpener : MonoBehaviour
{
    public GameObject Panel;

    public void OpenDatePicker(){
        if(Panel!=null){
            Panel.SetActive(true);
        }
    }
    public void CloseDatePicker(){
        if(Panel!=null){
            Panel.SetActive(false);
        }
    }
}
