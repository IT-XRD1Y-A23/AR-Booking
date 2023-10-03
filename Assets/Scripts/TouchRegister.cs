using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchRegister : MonoBehaviour
{

    WorkstationManager workstationManager;
    public TextMeshProUGUI debugText;

    // Start is called before the first frame update
    void Start()
    {
        workstationManager = WorkstationManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Camera.main != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject workstation = GetWorkstationParent(hit.transform.gameObject);
                    if (workstation == null)
                    {
                        debugText.text = "HIT = " + hit.transform.gameObject.name + " has no parent workstation!";
                    }
                    else
                    {
                        debugText.text = "HIT = " + workstation.name;
                        workstationManager.SetCurrentSelectedWorkstation(workstation);

                        openPopup(workstation);
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
    public GameObject workstationPopup;
    public void openPopup(GameObject workstation)
    {
        workstationPopup.SetActive(true);
    }
}
