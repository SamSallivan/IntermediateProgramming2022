using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    float timer = 0;
    public float amplitute = 0;

    void Start()
    {
        
    }
    public float easeOutBounce(float x){
        float n1 = 7.5625f;
        float d1 = 2.75f;

        if (x < 1 / d1) {
            return n1 * x * x;
        } else if (x < 2 / d1) {
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        } else if (x < 2.5 / d1) {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        } else {
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(0, Mathf.Sin(timer * amplitute), Mathf.Cos(timer * amplitute));

        if (Input.GetKey(KeyCode.Return)){
            timer = 0;
        }
    }
}
