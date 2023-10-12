using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkstationPopup : MonoBehaviour
{

    public GameObject workstationPopup;
    public SettingsData SettingsData;
    public TextMeshProUGUI title, description, selectedGroup, timeslot;

    public void Cancel()
    {
        workstationPopup.SetActive(false);
    }

    public void OpenPopup()
    {
        title.text = "Workstation " + SettingsData.SelectedWorkStationNumber;
        description.text = SettingsData.SelectedWorkStationDescription;
        selectedGroup.text = SettingsData.Group;
        timeslot.text = TimeSlots.ToString(SettingsData.Timeslot);

        workstationPopup.SetActive(true);
    }

    public void Book()
    {

        if (SettingsData.GroupIndex != 0)
        {
            workstationPopup.SetActive(false);
        }
        Debug.Log("Select a group before making a booking!");
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}