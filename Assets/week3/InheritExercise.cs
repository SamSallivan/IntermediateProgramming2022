using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritExercise : MonoBehaviour
{   
    public float dirx;
    public float diry;
    public float dirz;

    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position += new Vector3(dirx, diry, dirz);
    
        dirx = Random.Range(-0.1f, 0.1f);
        diry = Random.Range(-0.1f, 0.1f);
        dirz = Random.Range(-0.1f, 0.1f);

        if (Input.GetKeyDown(KeyCode.Space)){
            transform.position = new Vector3(0, 0, 0);
        }
    }

}

