using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using Random = System.Random;

public class WorkstationManager : MonoBehaviour
{

    public static WorkstationManager Instance { get; private set; }

    public  Status[] statuses = new Status[8];
    private readonly string[] _descriptions = new string[8];
    public LocalWorkstationManager[] workstations = new LocalWorkstationManager[8];
    
    private List<Booking> Bookings { get; set; } = new();

    public TextMeshProUGUI debugText;

    public SettingsData SettingsData;

    // Awake is called before Start.
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself. Basic Singleton stuff.
        
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
        // Init descriptions.
        
        _descriptions[0] = "PC, TV, Quest 2, webcam";
        _descriptions[1] = "PC, monitor, Quest 2, interactive table, webcam";
        _descriptions[2] = "PC, TV, Quest 2, 4 Xbox 360 Controllers";
        _descriptions[3] = "Quest, tv, monitor";
        _descriptions[4] = "Quest, monitor";
        _descriptions[5] = "Quest, monitor, Samsung portrait smart tv";
        _descriptions[6] = "Quest, monitor, Samsung Tablet";
        _descriptions[7] = "Quest, monitor";
        
        // Init statuses.

        for (var i = 1; i < workstations.Length + 1; i++)
        {
            SetWorkstationStatus(i, Status.Available);
        }

    }

    // Start is called before the first frame update.
    void Start()
    {
        // Get bookings from database and light up workstations which are reserved in the current timeslot chosen.
        
        // NOTE: This is mock data and the real data will most likely be using Async to avoid
        // that start is called before the bookings has been retrieved. A simple while loop checking if null might work too.
        Bookings = new List<Booking>
        {
            new Booking(2, DateTime.Now, 1, "2Y"),
            new Booking(4, DateTime.Now, 1, "2Y")
        };
                
        RefreshLights(Bookings);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (AllWorkstationsAreRegistered())
        {
            // Check for changes in bookings and change light colours accordingly.
            
            
            
        }
    }

    public void BtnChangeStatus()
    {
        var values = Enum.GetValues(typeof(Status));
        var random = new Random();
        
        for (int i = 1; i < workstations.Length+1; i++)
        {
            SetWorkstationStatus(i, (Status)values.GetValue((int)random.Next(values.Length-1)));
        }
    }

    /*
     *  SELECTION METHOD
     *  This code will detect which workstation is being selected by Raycast and turn the previously selected workstation off.
     */
    private LocalWorkstationManager _currentlySelectedWorkstation;
    private LocalWorkstationManager _previouslySelectedWorkstation;
    public void SetCurrentSelectedWorkstation(GameObject hit)
    {
        _currentlySelectedWorkstation = hit.GetComponent<LocalWorkstationManager>();
        var currentlySelectedWorkstationStatus = GetWorkstationStatus(_currentlySelectedWorkstation.GetWorkstationNumber());
        switch (currentlySelectedWorkstationStatus)
        {
            case Status.Available:
                SetWorkstationStatus(_currentlySelectedWorkstation.GetWorkstationNumber(), Status.Selected);
                if (_previouslySelectedWorkstation != null && _previouslySelectedWorkstation != _currentlySelectedWorkstation)
                    SetWorkstationStatus(_previouslySelectedWorkstation.GetWorkstationNumber(), Status.Available);
                _previouslySelectedWorkstation = _currentlySelectedWorkstation;
                //update SettingsData
                SettingsData.SelectedWorkStationNumber = _currentlySelectedWorkstation.GetWorkstationNumber();
                SettingsData.SelectedWorkStationDescription = GetWorkstationDescription(_currentlySelectedWorkstation.GetWorkstationNumber());
                break;
            default:
                return;
        }
        _currentlySelectedWorkstation.SetLight(Status.Selected);
    }

    public void RefreshLights(List<Booking> bookings)
    {
        
        foreach (var workstation in workstations)
        {
            SetWorkstationStatus(workstation.GetComponent<LocalWorkstationManager>().GetWorkstationNumber(), Status.Available);
        }
        foreach (var booking in bookings)
        {
            SetWorkstationStatus(booking.workstationNumber, Status.Unavailable);
        }
    }

    private bool AllWorkstationsAreRegistered()
    {
        if (workstations.All(o => o != null))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    /*
     * Getters and setters
     */
    
    // Workstation
    public void SetWorkstation(int index, LocalWorkstationManager workstation)
    {
        workstations[index - 1] = workstation;
    }
    // description of workstations
    public string GetWorkstationDescription(int workstationNumber)
    {
        return _descriptions[workstationNumber - 1];
    }


    // Status of workstations
    public Status GetWorkstationStatus(int workstationNumber)
    {
        return statuses[workstationNumber - 1];
    }

    public void SetWorkstationStatus(int workstationNumber, Status status)
    {
        statuses[workstationNumber-1] = status;
    }
    
    // Booking

    public void SetBookings(List<Booking> bookings)
    {
        Bookings = bookings;
    }
    
    public void SetBookings(Booking booking)
    {
        Bookings = new List<Booking> { booking };
    }
    
}
