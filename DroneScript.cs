using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class DroneScript : MonoBehaviour
{
    //objects to create prefabs of
    public GameObject destPrefab;
    private GameObject dest;

    public GameObject ObjPrefab;
    private GameObject newPickup;

    //necessary references
    private UIHandler UIH;
    private PlayerInventoryHandler PIH;
    private DoorScript door;

    //tracking the players progress
    private int playerProgress = 0;
    
    //info for rotation
    private int speed = 5;
    private int rotateRightTimer;

    // Start is called before the first frame update
    void Start()
    {

        //getting necessary components
        GameObject gob;
        gob = GameObject.Find("UIHandler");
        UIH = gob.GetComponent<UIHandler>();

        GameObject gob2;
        gob2 = GameObject.Find("PlayerInventoryHandler");
        PIH = gob2.GetComponent<PlayerInventoryHandler>();

        GameObject gob3;
        gob3 = GameObject.Find("Door");
        door = gob3.GetComponent<DoorScript>();


        //instantiating drone destination
        destPrefab = Instantiate(destPrefab, transform.position, Quaternion.identity);

        //getting drone destination
        dest = GameObject.Find("DroneDestination(Clone)");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //moving towards destination
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, dest.transform.position, speed * Time.deltaTime);
        
        //rotating right when needed
        if(rotateRightTimer > 0)
        {
            transform.RotateAround(gameObject.transform.position, new Vector3(0f, 1f, 0f), 30 * Time.deltaTime);

            rotateRightTimer = rotateRightTimer - 1;
        }


    }

    //when interacted with
    void HitByInteractRay()
    {
        print("hit drone");

        switch (playerProgress)
        {
            case 0://displaying message, then incrementing progress
                UIH.displayDroneString1();
                playerProgress = 1;
                break;

            case 1://if the player has the objective pickup, advancing the level. giving a dialogue line if else
                if(PIH.getObjectivePickupCount() == 0)
                {
                    UIH.displayText("Find me the spare parts, and I will open the door", 180f);
                }
                else
                {
                    UIH.displayText("Thank you, the door has been opened.", 180f);
                    playerProgress = 2;
                    PIH.incrementObjectivePickupCount(-1);

                    //spawning new pickup, then correcting position
                    newPickup = Instantiate(ObjPrefab, new Vector3(transform.position.x, transform.position.y - 0.9f, transform.position.z), transform.rotation);
                    newPickup.transform.localScale = new Vector3(100f, 100f, 100f);
                    newPickup.transform.SetParent(gameObject.transform, true);
                    newPickup.transform.Rotate(0f, 180f, 0f, Space.Self);
                    
                    //opening door
                    door.ChangeState();

                    //leaving the play area
                    Invoke("LeaveArea", 3f);
                }
                break;
        }
    }

    //moving drone into play area
    //called in the LaunchVent Script
    void Stage1()
    {
        //dest.MoveTo(new Vector3(32, 12, 10));
        dest.transform.SendMessage("MoveTo", new Vector3(32, 3, 10));

        //rotating drone
        rotateRightTimer = 180;
        //transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
        
    }

    //leaving play area, then despawning after a time
    void LeaveArea()
    {
        UIH.displayText("Goodbye...", 180f);

        dest.transform.SendMessage("MoveTo", new Vector3(-10, 35, 23));
        Invoke("Despawn", 5f);
        
    }

    //despawning
    void Despawn()
    {
        Destroy(newPickup);
        Destroy(gameObject);
    }
}
