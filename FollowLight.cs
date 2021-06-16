using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLight : MonoBehaviour
{

    public GameObject target;
    public string bind;
    private Light myLight;
    private bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //setting to target position
        this.transform.position = target.transform.position;
        this.transform.rotation = target.transform.rotation;

        //checking for input to change state
        if (Input.GetKeyDown(bind))
        {
            if(isOn)
            {
                myLight.intensity = 0;
                isOn = false;
            }
            else
            {
                myLight.intensity = 3;
                isOn = true;
            }
        }
        
    }
}
