using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

public class DatePickerHandler : MonoBehaviour
{


    public ToggleGroup toggleGroup;
    public GameObject[] toggles;
    public TextMeshProUGUI dateLabel;

    string pattern = @"8:00-12:00|12:00-16:00|16:00-00:00";

    public GameObject datePickerPanel;

    public SettingsData SettingsData;
    // Start is called before the first frame update
    void Start()
    {
        dateLabel.text = DateTime.Now.ToString("ddd, dd MMM") + " 8:00-12:00";
        SettingsData.Date = DateTime.Now;
        SettingsData.DateString = DateTime.Now.ToString("ddd, dd MMM");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OpenDatePicker()
    {
        datePickerPanel.SetActive(true);
    }
    public void CloseDatePicker()
    {
        datePickerPanel.SetActive(false);
    }

    public void Submit()
    {
        Regex regex = new Regex(pattern);
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].GetComponent<Toggle>().isOn)
            {
                if (regex.IsMatch(dateLabel.text))
                {
                    Debug.Log("matchers");
                    dateLabel.text = dateLabel.text.Substring(0, dateLabel.text.Length - 12);


                }
                dateLabel.text += " " + toggles[i].GetComponentInChildren<Text>().text;
                SettingsData.Timeslot = TimeSlots.ToTimeSlot(toggles[i].GetComponentInChildren<Text>().text);

            }
        }
    }
    public void SelectDate(DateTime date)
    {
        string selected = date.ToString("ddd, dd MMM");
        dateLabel.text = selected;
        SettingsData.Date = date;
        SettingsData.DateString = selected;
    }
}
