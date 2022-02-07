using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public float time = 0;
    public bool animation = false;
    public Vector3 target;
    public InputList inputList;

    void Start()
    {
        //inputList = FindObjectOfType<InputList>().gameObject;
        inputList = FindObjectOfType<InputList>();
        target = transform.position;  //set target position to its initial position so that it remains still. 
    }
    public float easeOutElastic(float x)
    {
        float c4 = (2 * Mathf.PI) / 3;

        return Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 5); 

        if (animation) //if button is clicked, play ease animation for 0.5s.
        {
            time = Mathf.Clamp(time + Time.deltaTime, 0f, 0.5f);
            transform.localScale = new Vector3(1 + easeOutElastic(time) * 0.5f, 1 + easeOutElastic(time) * 0.5f, 1 + easeOutElastic(time) * 0.5f);
        }

        if (time >= 0.5f) //resets values when animation ends.
        {
            animation = false;
            time = 0;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnMouseOver()
    {
        //Debug.Log("Enter");
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        if (Input.GetMouseButton(0) && time == 0 && inputList.inputButtonFake.Count < 10 && !inputList.reveal)
        {
            animation = true;

            GameObject button = Instantiate(gameObject,transform.position, transform.rotation); //creates a copy at the same position.
            inputList.inputButtonFake.Add(button); //adds the clone into inputList to be displayed.
            int rand = Random.Range(0, inputList.inputButtonReal.Count); 
            inputList.inputButtonReal.Insert(rand, button); //adds the clone into a second list at random index, for later reveal.
            button.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            //button.GetComponent<Clickable>().time = 1;
            button.transform.localScale = new Vector3(1, 1, 1);

            inputList.time = 0;
        }
    }
    private void OnMouseExit()
    {
        //Debug.Log("Exit");
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
