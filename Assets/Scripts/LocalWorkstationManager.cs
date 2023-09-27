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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLight(Status status)
    {
        _light.color = status.ToColor();
    }
    
    void OnMouseDown()
    {

        print("HELLO");

    }

    private int GetWorkstationNumber()
    {
        string[] words = gameObject.name.Split(' ');
        return Int32.Parse(words[1]);
    }
    
}
