using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    
    private bool isHeld = false;
    private GameObject dest;
    private float baseMass;

    // Start is called before the first frame update
    void Start()
    {
        //setting destination object
        dest = GameObject.Find("PickupDestination");

        //storing base mass
        baseMass = GetComponent<Rigidbody>().mass;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHeld)
        {
            //gameObject.transform.position = dest.transform.position;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, dest.transform.position, 8 * Time.deltaTime);

        }
    }

    //when interacted with
    void HitByInteractRay()
    {
        if (isHeld)
        {
            //re-enabling object gravity
            GetComponent<Rigidbody>().useGravity = true;

            //removing constraints
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            //resetting mass
            GetComponent<Rigidbody>().mass = baseMass;

            //updating isHeld
            isHeld = false;
            
        }
        else
        {
            //snapping to destination
            //gameObject.transform.position = dest.transform.position;

            //disabling object gravity while held
            GetComponent<Rigidbody>().useGravity = false;

            //applying constraints 
            //positions
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            //rotations
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            //lowering mass (prevents unwanted interactions with other placed objects)
            GetComponent<Rigidbody>().mass = 0f;

            //updating isHeld
            isHeld = true;
            
        }
        
    }
}
