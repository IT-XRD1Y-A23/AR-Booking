using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WorkstationManager : MonoBehaviour
{

    public static WorkstationManager Instance { get; private set; }
    
    // Start is called before the first frame update
    
    private Status[] statuses = new Status[8];
    public GameObject[] workstations = new GameObject[8];
    
    public TextMeshProUGUI debugText;

    private GameObject currentlySelectedWorkstation;
    private GameObject previouslySelectedWorkstation;
    
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
        for (int i = 0 ; i < statuses.Length; i ++)
        {
            statuses[i] = Status.Available;
        }
    }

    public void SetWorkstation(int index, GameObject workstation)
    {
        workstations[index-1] = workstation;
      //  print("Workstation " + index + " has been registered.");
    }

    public void SetCurrentSelectedWorkstation(GameObject hit)
    {
        currentlySelectedWorkstation = hit;
        debugText.text = "SELECTED = WORKSTATION " + currentlySelectedWorkstation.GetComponent<LocalWorkstationManager>().GetWorkstationNumber();
        Status currentlySelectedWorkstationStatus =
            statuses[currentlySelectedWorkstation.GetComponent<LocalWorkstationManager>().GetWorkstationNumber()-1];
        switch(currentlySelectedWorkstationStatus) 
        {
            case Status.Unavailable:
                return;
            case Status.Selected:
                SetWorkstationStatus(currentlySelectedWorkstation.GetComponent<LocalWorkstationManager>().GetWorkstationNumber()-1, Status.Available);
                break;
            case Status.Available:
                SetWorkstationStatus(currentlySelectedWorkstation.GetComponent<LocalWorkstationManager>().GetWorkstationNumber()-1, Status.Selected);
                if(previouslySelectedWorkstation != null)
                    SetWorkstationStatus(previouslySelectedWorkstation.GetComponent<LocalWorkstationManager>().GetWorkstationNumber()-1, Status.Available);
                previouslySelectedWorkstation = currentlySelectedWorkstation;
                break;
        }
        
        currentlySelectedWorkstation.GetComponent<LocalWorkstationManager>().SetLight(Status.Selected);
        
        
        
    }
    
    private static GameObject GetWorkstationParent(GameObject currentGameObject)
    {
            if (currentGameObject.name.Contains("Workstation") && currentGameObject.name.Length == 13)
            {
                return currentGameObject.gameObject;
            }

            if (currentGameObject.transform.parent != null)
            {
                GetWorkstationParent(currentGameObject.transform.parent.gameObject);
            }

            return null;
    }

    // Update is called once per frame
    void Update()
    {
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
        workstations[workstationNumber].GetComponent<LocalWorkstationManager>().SetLight(status);
        statuses[workstationNumber] = status;
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
