using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractScript : MonoBehaviour
{
    public string keyBind;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Interacting using raycasts
        if(Input.GetKeyDown(keyBind))
        {
            //creating forward vector and assigning hit object
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;


            //applying a layermask to only cast rays against interactable objects
            int layerMask = 1 << 9;


            //casting ray
            if (Physics.Raycast(this.transform.position, fwd, out hit, 5, layerMask))
            {
                //Telling hit objects to run their HitByInteractRay() methods if they have them
                hit.transform.SendMessage("HitByInteractRay");

                //Debug drawing ray if hit
                Debug.DrawRay(this.transform.position, fwd * 5, Color.green, 10, false);

                //printing what was hit
                print("Object Hit: " + hit.collider);
            }
            else
            {
                //Debug drawing ray if not hit
                Debug.DrawRay(this.transform.position, fwd * 5, Color.red, 10, false);

                //printing nohit
                print("No interactable object hit");
            }

        }
    }
    
}
