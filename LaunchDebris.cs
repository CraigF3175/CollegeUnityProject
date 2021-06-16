using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchDebris : MonoBehaviour
{
    //public Rigidbody[] debris = new Rigidbody[9];
    public Rigidbody[] debris;

    void OnTriggerEnter(Collider ent)
    {
        //for each piece of debris, launching at a randome speed
        for (int i = 0; i < 11; i++)
        {
            debris[i].AddRelativeForce(new Vector3(0, 0, Random.Range(500, 1000)));
        }

        //destroying trigger
        Destroy(this);
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
