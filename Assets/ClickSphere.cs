using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSphere : MonoBehaviour
{
    Light lightComp;

    // Start is called before the first frame update
    void Start()
    {

        print(gameObject.name);
        lightComp = gameObject.AddComponent<Light>();
        lightComp.color = Color.green;
        lightComp.intensity = 1;

    }
    // sadasd
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){

        if(lightComp.enabled)
        {
            lightComp.enabled = false;
        } else
        {
            lightComp.enabled = true;
        }


    }





}
