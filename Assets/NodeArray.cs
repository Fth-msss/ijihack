using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeArray : MonoBehaviour
{
    [SerializeField]
    GameObject[] allNodes;
   

    private void Awake()
    {
        allNodes = new GameObject[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            allNodes[i] = child.gameObject;
            i = i + 1;
        }
    }

    public GameObject[,] RemadeNodeCollector(int length,int width) //hopefully,this should be working
    {
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
                    k++;
                    nodeArray[i, l].SetActive(true);
                    nodeArray[i, l].GetComponent<NodeState>().State = "empty";

                }
            }
            nodeArray[0, 0].GetComponent<NodeState>().State = "agent";
            nodeArray[nodeArray.GetLength(0)-1,nodeArray.GetLength(1)-1].GetComponent<NodeState>().State = "exit";
            return nodeArray;
        }

      
       
      
    }


}
