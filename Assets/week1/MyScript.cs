using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    public GameObject MyPrefab;
    public float maxCheems;
    Vector3 RandLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cheems[] count = FindObjectsOfType(typeof(Cheems)) as Cheems[];
        //Debug.Log(count.Length);
        
        if (count.Length < maxCheems)
        {
            RandLocation = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(0, 5f), Random.Range(-10.0f, 10.0f));
            GameObject cheems = Instantiate(MyPrefab, RandLocation, Quaternion.identity);
            cheems.transform.Rotate(-90.0f, 0.0f, Random.Range(0.0f, 360.0f), Space.Self);
        }

        if (Input.GetKey(KeyCode.Space)){
        }
    }
}
