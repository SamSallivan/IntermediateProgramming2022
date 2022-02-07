using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputList : MonoBehaviour
{

    public List<GameObject> inputButtonReal = new List<GameObject>();
    public List<GameObject> inputButtonFake = new List<GameObject>();
    public float time = 0;
    public bool reveal = false;
    public bool sorted = true;

    void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime;

        for (int i = 0; i < inputButtonFake.Count; i++)
        {
            inputButtonFake[i].GetComponent<Clickable>().target = new Vector3(transform.position.x - ((inputButtonFake.Count - 1) * 0.5f) + i, transform.position.y, transform.position.z);
        } //lerps the displayed inputlist buttons to traget position in ascending order.

        if (!reveal)
        {
            if (time >= 1.5f)
            {
                time = 0;
                if(inputButtonFake.Count > 0)
                    reveal = true;
            }
        }
        else //reveals in the order of the second list
        {
            do
            {

                for (int i = 0; i < inputButtonReal.Count - 1; i++)
                {

                    sorted = true;

                    if (inputButtonReal.IndexOf(inputButtonFake[i]) > inputButtonReal.IndexOf(inputButtonFake[i + 1]))
                    {
                        GameObject temp = inputButtonFake[i];
                        inputButtonFake[i] = inputButtonFake[i + 1];
                        inputButtonFake[i + 1] = temp;
                        sorted = false;
                    }
                }

            } while (!sorted); //bubble sorts the displayed inputList in the order of the hidden second list.

            if (time >= 1)
            {
                time = 0;
                reveal = false;

                foreach (GameObject input in inputButtonFake)
                {
                    Destroy(input);
                }
                inputButtonFake.Clear();
                inputButtonReal.Clear();
            }
        }


    }
}
