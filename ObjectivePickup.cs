using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePickup : MonoBehaviour
{
    private PlayerInventoryHandler PIH;

    // Start is called before the first frame update
    void Start()
    {
        //getting the inventory handler to allow for holding of the pickup
        GameObject gob;
        gob = GameObject.Find("PlayerInventoryHandler");
        PIH = gob.GetComponent<PlayerInventoryHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HitByInteractRay()
    {
        //incrementing pickup counter, then destroying self to act like the object has been picked up and stored
        PIH.incrementObjectivePickupCount(1);
        Destroy(gameObject);
    }
}
