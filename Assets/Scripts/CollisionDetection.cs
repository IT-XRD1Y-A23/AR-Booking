using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    GameObject workstation;
    public TextMeshProUGUI mText; 
    
    // Start is called before the first frame update
    void Start()
    {
        workstation = GetWorkstationParent(gameObject);
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
                        mText.text = "HIT = " + hit.transform.gameObject.name + " has no parent workstation!";
                    }
                    else
                    {
                        mText.text = "HIT = " + workstation.name;
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

    void OnMouseDown()
    {
        
        print(workstation.name);
        
        workstation.GetComponent<LocalWorkstationManager>().SetLight(Status.Selected);
    }

}
