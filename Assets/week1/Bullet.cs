using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public float speed = 0f;
    public float time = 0f;
    public float maxTime = 5f;
    public Vector3 dir;


    void Start()
    {
        dir = Camera.main.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        time = Mathf.Clamp(time + Time.deltaTime, 0f, maxTime);
        transform.position = Vector3.Lerp(transform.position, transform.position + dir, time*2/maxTime);

        if(time == maxTime)
        {
            Destroy(gameObject);
        }
    }
}
