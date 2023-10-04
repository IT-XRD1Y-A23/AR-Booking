using System;
using UnityEngine;

public class LocalWorkstationManager : MonoBehaviour
{

    public GameObject lightObject;
    private Light _light;
    private WorkstationManager _workstationManager;

    // Start is called before the first frame update
    private void Start()
    {
        _light = lightObject.GetComponent<Light>();

        _workstationManager = WorkstationManager.Instance;
        _workstationManager.SetWorkstation(GetWorkstationNumber(), gameObject);
    }

    private void Update()
    {
        if (_workstationManager != null)
        {
            SetLight(_workstationManager.GetWorkstationStatus(GetWorkstationNumber()));
        }
    }

    public void SetLight(Status status)
    {
        _light.color = status.ToColor();
    }

    public int GetWorkstationNumber()
    {
        string[] words = gameObject.name.Split(' ');
        return int.Parse(words[1]);
    }

}
