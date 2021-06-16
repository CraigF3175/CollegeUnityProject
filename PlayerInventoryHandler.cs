using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryHandler : MonoBehaviour
{
    private int objectivePickupCount = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //allowing for interaction from objectivePickup
    public void incrementObjectivePickupCount(int num)
    {
        objectivePickupCount = objectivePickupCount + num;
    }



    //getters

    public int getObjectivePickupCount()
    {
        return objectivePickupCount;
    }

}
