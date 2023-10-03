using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkstationPopup : MonoBehaviour
{


    public GameObject workstationPopup;

    public void Cancel()
    {
        workstationPopup.SetActive(false);
    }
    public void Book()
    {

        workstationPopup.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
