using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneDestination : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //moving to a new location
    //this method is called by the drone, and the drone is always moving towards this marker
    public void MoveTo(Vector3 newDest)
    {
        gameObject.transform.position = newDest;
    }
}
