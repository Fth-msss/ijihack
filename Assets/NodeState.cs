using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NodeState : MonoBehaviour
{
    [SerializeField]
   private string state;
    Image childcolor;
    private void Awake()
    {
        //this comically does not get components in children rather gets it from parent.
        childcolor = GetComponentInChildren<Image>();
    }

    public string State 
    {
        get { return state; }
        set { state = value; ChangeColor(); }
    }
    
    void ChangeColor() 
    {
        switch (state) 
        {
            case "empty":
                childcolor.color = Color.white;
                break;
            case "agent":
                childcolor.color = Color.green;
                break;
            case "obstacle":
                childcolor.color = Color.black;
                break;
            case "exit":
                childcolor.color = Color.red;
                break;
        
        }
    }
}
