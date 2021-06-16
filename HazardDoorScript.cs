using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardDoorScript : MonoBehaviour
{
    private GameObject dest;
    public GameObject destPrefab;


    // Start is called before the first frame update
    void Start()
    {
        //Instantiating destination
        dest = Instantiate(destPrefab, transform.position, Quaternion.identity);
        
        
        //beginning at a random time to create desync between multiple instances
        Invoke("Open", Random.Range(1, 8));
        
    }

    // Update is called once per frame
    void Update()
    {
        //moving towards destination
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, dest.transform.position, 3 * Time.deltaTime);
    }

    //opening door
    void Open()
    {
        dest.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4);
        Invoke("Close", 2f);
    }

    //closing door
    void Close()
    {
        dest.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 4);
        Invoke("Open", 2f);
    }
}
