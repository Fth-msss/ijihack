using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeArray : MonoBehaviour
{
    [SerializeField]
    GameObject[] allNodes;
   

    private void Awake()//get all nodes to array
    {
        allNodes = new GameObject[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            allNodes[i] = child.gameObject;
            i++;
        }

       
    }

 

    //put nodes in allNodes to a 2d array
    public GameObject[,] CreateGameArray(int length,int width) 
    {
        if (allNodes[1].activeSelf) { foreach (GameObject child in allNodes) { child.SetActive(false); } }
        
        int k = 0;

        if (length * width > transform.childCount) { Debug.Log("node limit exceeded");return null; }
        else 
        {
            GameObject[,] nodeArray = new GameObject[length, width];

            for (int i = 0; i < length; i++) 
            {
                for (int l = 0; l < width; l++)
                {
                  
                    nodeArray[i, l] = allNodes[k];
                    nodeArray[i, l].GetComponent<NodeState>().State = "empty";
                    nodeArray[i, l].SetActive(true);
                    k++;

                }
            }
            //spawns start node and finish node at the start and end of array.
            nodeArray[0, 0].GetComponent<NodeState>().State = "agent";
            nodeArray[nodeArray.GetLength(0)-1,nodeArray.GetLength(1)-1].GetComponent<NodeState>().State = "exit";
            GetComponent<GridLayoutGroup>().constraintCount = nodeArray.GetLength(1);
            return nodeArray;
        }

      
       
      
    }


}
