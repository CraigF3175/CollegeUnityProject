using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchVent : MonoBehaviour
{
    public Rigidbody vent;
    public Collider playerDetect;

    void OnTriggerEnter(Collider ent)
    {
        //launching vent if touching player
        if (ent == playerDetect)
        {
            vent.AddRelativeForce(new Vector3(200, 40, 0));

            //sending message to drone
            MessageDrone();

            //destroying trigger
            Destroy(this);
        }
        
    }
    
    //telling drone to do stuff
    void MessageDrone()
    {
        GameObject gob;
        gob = GameObject.Find("Drone1");
        gob.transform.SendMessage("Stage1");
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
