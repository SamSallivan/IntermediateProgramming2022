using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward;
        timer+= Time.deltaTime;
        if(timer >= 3f){
            this.gameObject.SetActive(false);
        }
    }
}
