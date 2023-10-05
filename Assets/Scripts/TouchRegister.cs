using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchRegister : MonoBehaviour
{
    private WorkstationManager _workstationManager;
    public TextMeshProUGUI debugText;

    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
        _workstationManager = WorkstationManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (_camera is not null)
            {
                Ray ray = _camera.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject workstation = GetWorkstationParent(hit.transform.gameObject);
                    if (workstation is null)
                    {
                        debugText.text = "HIT = " + hit.transform.gameObject.name + " has no parent workstation!";
                    }
                    else
                    {
                        if (!datePickerPopup.activeSelf && !groupsPopup.activeSelf && !bookingsPopup.activeSelf)
                        {
                            debugText.text = "HIT = " + workstation.name;
                            _workstationManager.SetCurrentSelectedWorkstation(workstation);
                            //OpenPopup(workstation);
                        }
                    }
                }
            }
        }
    }

    private GameObject GetWorkstationParent(GameObject currentGameObject)
    {
        while (true)
        {
            if (currentGameObject.name.Contains("Workstation") && currentGameObject.name.Length == 13)
            {
                return currentGameObject.gameObject;
            }
            else
            {
                currentGameObject = currentGameObject.transform.parent.gameObject;
            }
        }
    }

    public GameObject datePickerPopup;
    public GameObject groupsPopup;
    public GameObject bookingsPopup;

    public GameObject workstationPopup;
    private Camera _camera;

    private void OpenPopup(GameObject workstation)
    {
        workstationPopup.SetActive(true);
    }
}