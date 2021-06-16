using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorInteract : MonoBehaviour
{
    public ParticleSystem explosion;


    // When trigger is touched by player
    void OnTriggerEnter(Collider ent)
    {
        
    }

    //when interacted with
    void HitByInteractRay()
    {
        print("hit by ray");

        //Playing Explosion Effect
        explosion.Play();

        //Destroying trigger
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
