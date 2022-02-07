using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheems : MonoBehaviour
{
    public float health = 2f;
    public float time = 0;
    public float maxTime;
    public float amplitute;
    public bool sin = false;
    //public bool hit1 = false;
    //public bool hit2 = false;
    public float time1 = 0;
    public float time2 = 0;
    public Vector3 target;
    public Vector3 start;
    //public Color originalColor;


    void Start()
    {
        start = transform.position;
        target = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(0, 5f), Random.Range(-10.0f, 10.0f));
        maxTime = Random.Range(2f, 5f);
        //originalColor = this.GetComponent<Renderer>().material.color;
    }

    public float easeOutElastic(float x)
    {
        float c4 = (2 * Mathf.PI) / 3;

        return Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1;
    }

    void Update()
    {
        time = Mathf.Clamp(time + Time.deltaTime, 0f, maxTime);

        if (sin)
        {
            transform.position = Vector3.Lerp(start, target, time / maxTime) + new Vector3(0f, amplitute * Mathf.Sin(time), 0.0f);
        }
        else
        {
            transform.position = Vector3.Lerp(start, target, time / maxTime);
        }

        if (time == maxTime)
        {
            time = 0;
            sin = (Random.value > 0.5f);
            amplitute = Random.Range(-10.0f, 10.0f);
            start = transform.position;
            target = new Vector3(Random.Range(-25.0f, 25.0f), Random.Range(0, 10f), Random.Range(-25.0f, 25.0f));
            maxTime = Random.Range(2f, 5f);
        }

        if (transform.position == target)
        {
        }

        if (health == 1)
        {
            time1 = Mathf.Clamp(time1 + Time.deltaTime, 0f, 0.5f);
            transform.localScale = new Vector3(100 + easeOutElastic(time1) * 50, 100 + easeOutElastic(time1) * 50, 100 + easeOutElastic(time1) * 50);
            this.GetComponent<Renderer>().material.SetColor("_color",Color.Lerp(Color.black, Color.red, time1/0.5f));
        }

        if (health <= 0)
        {
            time2 = Mathf.Clamp(time2 + Time.deltaTime, 0f, 0.5f);
            transform.localScale = new Vector3(150 + easeOutElastic(time2) * 50, 150 + easeOutElastic(time2) * 50, 150 + easeOutElastic(time2) * 50);
            //this.GetComponent<Renderer>().material.SetColor("_color", Color.Lerp(Color.black, Color.red, time1 / 0.5f));
            
            if(time2 >= 0.1)
                Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("hit");
        if (collision.gameObject.GetComponent<Bullet>())
        {
            health -= 1;
            Destroy(collision.gameObject);
            Debug.Log("hit");
        }
    }
}
