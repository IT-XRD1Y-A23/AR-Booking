using System;
using UnityEngine;

public class LocalWorkstationManager : MonoBehaviour
{

    public GameObject lightObject;
    private Light _light;
    private int workstationNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        _light = lightObject.GetComponent<Light>();

        workstationNumber = getWorkstationNumber();

        print(workstationNumber);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLight(Status status)
    {
        _light.color = status.ToColor();
    }
    
    void OnMouseDown(){
        
        
        
    }

    private int getWorkstationNumber()
    {
        string[] words = gameObject.name.Split(' ');
        return Int32.Parse(words[1]);
    }
    
}
