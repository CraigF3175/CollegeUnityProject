using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text textOutput;
    public Image backingImage;
    private RectTransform rect;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        //getting rect transform component
        //(needed for centring resized text)
        rect = GetComponent<RectTransform>();

        //setting initial properties
        textOutput.fontSize = 30;
        textOutput.color = Color.white;

        //displaying initial text
        displayMessage1();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //called every frame
    void FixedUpdate()
    {
        //emptying text when timer runs out
        if (timer <= 0)
        {
            textOutput.text = "";

            backingImage.color = new Color(backingImage.color.r, backingImage.color.g, backingImage.color.b, 0f);
        }
        else
        {
            //decrementing timer
            timer = timer - 1;

            //keeping backing image onscreen while displaying text
            backingImage.color = new Color(backingImage.color.r, backingImage.color.g, backingImage.color.b, 1f);
        }
    }

    //displaying initial message
    void displayMessage1()
    {
        textOutput.text = "Where... am I...?";
        timer = 180f;
    }

    //displaying first set of drone messages --------------------------------------------------------------
    public void displayDroneString1()
    {
        DroneMessage1();
        Invoke("DroneMessage2", 3f);
        Invoke("DroneMessage3", 6f);
    }

    void DroneMessage1()
    {
        textOutput.text = "Hello";
        timer = 180f;
    }

    void DroneMessage2()
    {
        textOutput.text = "I can help you get out of here...";
        timer = 180f;
    }

    void DroneMessage3()
    {
        textOutput.text = "If you can find me a box of spare parts, I will hack open the door over there.";
        timer = 180f;
    }
    //-----------------------------------------------------------------------------------------------------
    
    //method for assigning new message and display length
    public void displayText(string message, float displayLength)
    {
        textOutput.text = message;
        timer = displayLength;
    }
}
