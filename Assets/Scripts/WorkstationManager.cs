using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorkstationManager : MonoBehaviour
{

    public static WorkstationManager Instance { get; private set; }
    
    // Start is called before the first frame update
    
    private Status[] statuses = new Status[8];
    public GameObject[] workstations = new GameObject[8];
    
    
    
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    
    
    
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            
        }
    }

    public void SetWorkstation(int index, GameObject workstation)
    {
        workstations[index-1] = workstation;
        print("Workstation " + index + " has been registered.");
    }

    // Update is called once per frame
    void Update()
    {
        if (workstations.All(o => o != null))
        {
            
        }
    }

    void StartupLights()
    {
        for (int i = 0; i < statuses.Length; i++)
        {
            statuses[i] = Status.Unavailable;
        }
    }

    void SetWorkstationStatus(int workstationNumber, Status status)
    {
        workstations[0].GetComponent<LocalWorkstationManager>().SetLight(status);
    }
    
    private bool AreAllWorkstationsRegistered()
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

    public GameObject GetWorkstation(int index)
    {
        if (workstations[index] != null)
        {
            print("Works fine");
            return workstations[index];
        }
        else
        {
            print("Works not fine");
            return workstations[index + 1];
        }
    }
    
}
