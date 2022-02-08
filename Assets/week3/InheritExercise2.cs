using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InheritExercise2 : InheritExercise
{
    // Start is called before the first frame update
    public bool blink;
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        GetComponent<Renderer>().enabled = blink;

        if (Input.GetKeyDown(KeyCode.Space)){
            blink = !blink;
        }
        
    }
    public Color MaterialColor{

        get
        {
            return GetComponent<Renderer>().material.color;
        }

        private set // HitPoints cannot be set outside of class “Player”
        {
            GetComponent<Renderer>().material.color = value;
        }

    }
}