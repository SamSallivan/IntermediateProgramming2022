using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject myFish;
    public GameObject bullet;
    public float time1 = 0;
    public bool shot = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float easeOutElastic(float x)
    {
        float c4 = (2 * Mathf.PI) / 3;

        return Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1;
    }

    void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Debug.DrawRay(cam.transform.position, cam.transform.transform.forward, Color.red, 10000);

            GameObject fish = Instantiate(bullet, myFish.transform.position, Quaternion.Euler(myFish.transform.eulerAngles.x, myFish.transform.eulerAngles.y, myFish.transform.eulerAngles.z));

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
            }

            time1 = 0.0f;
            shot = true;
        }

        if (shot)
        {
            time1 = Mathf.Clamp(time1 + Time.deltaTime, 0f, 0.25f);
            myFish.transform.localScale = new Vector3(0.01f + Mathf.Sin(time1 * 4 * Mathf.PI) * 0.005f, 0.01f + Mathf.Sin(time1 * 4 * Mathf.PI) * 0.005f, 0.01f + Mathf.Sin(time1 * 4 * Mathf.PI) * 0.005f);
            //this.GetComponent<Renderer>().material.SetColor("_color", Color.Lerp(Color.black, Color.red, time1 / 0.5f));
            Debug.Log(time1);
            if (time1 >= 0.5f)
            {
                time1 = 0.0f;
                shot = false;
            }
        }
    }
}
