using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour {

    public Material m_matOfObject;

    Color rightCol = Color.green;
    Color wrongCol = Color.red;

  //  public Color m_newCol;
    public GameObject obj;
    string ans;
   

    // Use this for initialization
    void Start()
    {
      //  m_matOfObject.color = Color.white;
       
        Debug.Log(ans);
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void NewColour()
    {
        ans = obj.GetComponent<CSVHandler>().GetAnswer();
        Debug.Log(gameObject.tag);
        Debug.Log(ans);

        if ((gameObject.tag == "answerA")&&(ans == "A"))
        {
            Debug.Log("Right");
            gameObject.GetComponent<Renderer>().material.color = rightCol;
        }

        else if ((gameObject.tag == "answerB") && (ans == "B"))
        {
            Debug.Log("Right");
            gameObject.GetComponent<Renderer>().material.color = rightCol;
        }

        else if ((gameObject.tag == "answerC") && (ans == "C"))
        {
            Debug.Log("Right");
            gameObject.GetComponent<Renderer>().material.color = rightCol;
        }
        else if ((gameObject.tag == "answerD") && (ans == "D"))
        {
            Debug.Log("Right");
            gameObject.GetComponent<Renderer>().material.color = rightCol;
        }

        else
        {
            Debug.Log("Wrong");
            gameObject.GetComponent<Renderer>().material.color = wrongCol;
        }
    }
}
