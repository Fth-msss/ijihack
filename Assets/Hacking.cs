using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hacking : MonoBehaviour
{
    GameObject[,] nodeArray;
    public GameObject neww;
    public RectTransform coordinates;
 
    void Start()
    {
      nodeArray=  neww.GetComponent<NodeArray>().RemadeNodeCollector(5,5);

        ConstructHackingTable(25,-35);
    }

   
    void ConstructHackingTable(int xmov,int ymove)  //set node table
    {
        
        float xcords= neww.transform.position.x;//get coords of first node to put
        float ycords= neww.transform.position.y;
        Vector2 cor= new Vector2(xcords, ycords);


        for (int i = 0; i < nodeArray.GetLength(0); i++)//spawn nodes
        {
            cor = cor + new Vector2(xmov * -5, ymove);
            for (int l = 0; l < nodeArray.GetLength(1); l++)
            {
                cor = cor + new Vector2(xmov, 0);
                GameObject childe= nodeArray[i, l];
                childe.transform.position = cor;

            }
        }

    }

   


    public void MoveNode(string str)// somehow get startnode positions and arraysizes
    {
        int startnodeposx = 0;
        int startnodeposy = 0;
        int  arrsizex = 5,arrsizey=5;
       switch (str)
            {
            case "up":
                if (startnodeposy - 1 < 0) { Debug.Log("out of bounds"); }//fail out of bounds
                else if (nodeArray[startnodeposx,startnodeposy-1].GetComponent<NodeState>().State=="obstacle") { Debug.Log("hit obstacle"); }// fail hit block node
                nodeArray[startnodeposx, startnodeposy].GetComponent<NodeState>().State = "obstacle";
                nodeArray[startnodeposx, startnodeposy - 1].GetComponent<NodeState>().State = "agent";

                break;
            case "down":
                if (startnodeposy + 1 > arrsizey) { Debug.Log("out of bounds"); }//fail out of bounds
                else if (nodeArray[startnodeposx, startnodeposy + 1].GetComponent<NodeState>().State == "obstacle") { Debug.Log("hit obstacle"); }// fail hit block node
                nodeArray[startnodeposx, startnodeposy].GetComponent<NodeState>().State = "obstacle";
                nodeArray[startnodeposx, startnodeposy + 1].GetComponent<NodeState>().State = "agent";
                break;
            case "left":
                if (startnodeposx - 1 < 0) { Debug.Log("out of bounds"); }//fail out of bounds
                else if (nodeArray[startnodeposx, startnodeposy - 1].GetComponent<NodeState>().State == "obstacle") { Debug.Log("hit obstacle"); }// fail hit block node
                nodeArray[startnodeposx, startnodeposy].GetComponent<NodeState>().State = "obstacle";
                nodeArray[startnodeposx, startnodeposy - 1].GetComponent<NodeState>().State = "agent";
                break;
            case "right":
                if (startnodeposx + 1 < arrsizex) { Debug.Log("out of bounds"); }//fail out of bounds
                else if (nodeArray[startnodeposx, startnodeposy + 1].GetComponent<NodeState>().State == "obstacle") { Debug.Log("hit obstacle"); }// fail hit block node
                nodeArray[startnodeposx, startnodeposy].GetComponent<NodeState>().State = "obstacle";
                nodeArray[startnodeposx, startnodeposy + 1].GetComponent<NodeState>().State = "agent";
                break;
        }
    }


    // okay maybe leave these for later

    void PathFinder() 
    {//puts obstacles 
        int xsize=5, ysize=5;

        for (int i = 0; i < xsize; i++) //length
        {
            if (i == 0) {  }//empty
            else 
            {
                if (i == 1) { Obstacler(Random.Range(0, ysize - 1),ysize);  }

            }

        }
    
    }

    int Obstacler(int number,int size) 
    {
        if (Random.value < 0.1) { }
        

        return 0;
    }

}
