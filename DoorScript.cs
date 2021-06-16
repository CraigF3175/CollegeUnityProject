using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool isOpen = false;
    private GameObject dest;
    
    // Start is called before the first frame update
    void Start()
    {
        dest = GameObject.Find("DoorDestination");
    }

    // Update is called once per frame
    void Update()
    {
        //moving towards destiation marker
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, dest.transform.position, 3 * Time.deltaTime);
    }

    //altering the state of the door based on its current state
    public void ChangeState()
    {
        if(isOpen)
        {
            dest.transform.position = new Vector3(18f, 2.5f, 4.5f);
            isOpen = false;
        }
        else
        {
            dest.transform.position = new Vector3(18f, 5f, 4.5f);
            isOpen = true;
        }
    }
}
