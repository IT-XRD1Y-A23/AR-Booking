using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkstationPopup : MonoBehaviour
{

    private FirebaseDao _firebaseDao;
    private WorkstationManager _workstationManager;
    public GameObject workstationPopup;
    public SettingsData SettingsData;
    public TextMeshProUGUI title, description, selectedGroup, timeslot;

    void Start()
    {
        _firebaseDao = new();
        _workstationManager = WorkstationManager.Instance;
    }
    
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

            Booking selectedBooking = new Booking(
                SettingsData.SelectedWorkStationNumber.ToString(),
                SettingsData.Date,
                SettingsData.Timeslot,
                SettingsData.Group
                );
            
            _firebaseDao.TryCreateBooking(selectedBooking, 
                () => 
                {
                    // Success callback: Log a success message.
                    
                    _firebaseDao.FetchBookingsForDate(SettingsData.Date.ToString("dd-MM-yyyy"), bookingList =>
                    {
                        foreach (var booking in bookingList)
                        {
                            Debug.Log($"Retrieved booking for group: {booking.groupNumber} {booking.id}");
                        }
            
                        _workstationManager.RefreshLights(bookingList, SettingsData.Timeslot);
            
                    }, error =>
                    {
                        // Failure callback: Log the error for debugging purposes.
                        Debug.LogError($"Error retrieving bookings for {SettingsData.Date:dd-MM-yyyy}: {error}");
                    });
                    
                    Debug.Log("Booking succeeded!");
                },
                errorMessage => 
                {
                    // Failure callback: Log the received error message.
                    Debug.LogError($"Booking failed: {errorMessage}");
                }
            );
            
        }
        Debug.Log("Select a group before making a booking!");
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}