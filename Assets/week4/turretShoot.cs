using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bullet;
    private float timer;
    private int cycle = 0;
        private List<GameObject> objectPool = new List<GameObject>();
    void Awake()
    {
        for(int i = 0; i < 7; i++){
            GameObject b = Instantiate(bullet,transform.position, Quaternion.identity);
            objectPool.Add(b);
            b.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 0.5f) {
            timer = 0;
            objectPool[cycle].transform.position = transform.position;
            objectPool[cycle].SetActive(true);
            objectPool[cycle].GetComponent<bullet>().timer = 0;
            cycle++;
        }

        if(cycle >= 7){
            cycle = 0;
        }

        if(Time.time > 3.0f){
            //Destroy(this.gameObject);
        }
    }
}
