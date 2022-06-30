using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NodeState : MonoBehaviour
{
    private string state;
    Image childcolor;
    private void Awake()
    {
        //there is only one child why am i doing this
        foreach(Transform child in transform) { childcolor = child.GetComponent<Image>(); }
    }

    public string State 
    {
        get { return state; }
        set { state = value; ChangeColor(); }
    }
    
    void ChangeColor() 
    {
        if (childcolor == null) { foreach (Transform child in transform) { childcolor = child.GetComponent<Image>(); } }

        switch (state) 
        {
            case "empty":
                childcolor.color = Color.white;
                break;
            case "agent":
                childcolor.color = Color.green;
                break;
            case "obstacle":
                childcolor.color = Color.blue;
                break;
            case "exit":
                childcolor.color = Color.red;
                break;
            case "debug":
                childcolor.color = Color.yellow;
                break;
        
        }
    }
}
