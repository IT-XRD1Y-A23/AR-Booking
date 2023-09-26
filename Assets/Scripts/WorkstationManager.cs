using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkstationManager : MonoBehaviour
{

    public static WorkstationManager Instance { get; private set; }
    
    // Start is called before the first frame update
    
    private Status[] statuses = new Status[8];
    //private GameObject[] workstations;
    
    void Start()
    {
        //workstations = new GameObject[8];
        //StartupLights();
    }

    /*public void setWorkstation(int index, GameObject workstation)
    {
        workstations[index-1] = workstation;
    }*/

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
    
}
