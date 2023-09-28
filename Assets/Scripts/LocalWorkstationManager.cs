using System;
using UnityEngine;

public class LocalWorkstationManager : MonoBehaviour
{

    public GameObject lightObject;
    private Light _light;

    // Start is called before the first frame update
    void Start()
    {
        _light = lightObject.GetComponent<Light>();
        
        WorkstationManager workstationManager = WorkstationManager.Instance;
        workstationManager.SetWorkstation(GetWorkstationNumber(), gameObject);
    }

    public void SetLight(Status status)
    {
        _light.color = status.ToColor();
    }

    public int GetWorkstationNumber()
    {
        string[] words = gameObject.name.Split(' ');
        return Int32.Parse(words[1]);
    }
    
}
