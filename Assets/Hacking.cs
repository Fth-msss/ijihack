using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Hackingminigame { 
public class Hacking : MonoBehaviour
{
    GameObject[,] nodeArray;
    public GameObject nodeList;
    public RectTransform coordinates;


    [Header("variables")]
    [SerializeField]
    [Tooltip("give length and width of game array")]
    Vector2 gamearraything;
    [SerializeField]
    [Tooltip("test")]
    int gamearraylengthx=5;
    [SerializeField]
    int gamearraylengthy=5;

    [SerializeField]
    float hackingtime = 10;
    [SerializeField]
    bool isTimed;
    [SerializeField]
    TextMeshProUGUI time;

    [SerializeField]
    TextMeshProUGUI hackingstate;

    //i dont know if i should do this
    public bool IsTimed
        {
        get { return isTimed; }
        set { isTimed = value;  }
    }



    public void StartMinigame() 
    {
        StopAllCoroutines();
        startnodepos = new Vector2(0, 0);
        nodeArray = nodeList.GetComponent<NodeArray>().CreateGameArray(gamearraylengthx, gamearraylengthy);
       
        GameArray();
        if (isTimed) { StartCoroutine(HackTime(hackingtime)); }
        hackingstate.text = "ongoing hacking";
    }




    float currCountdownValue;
    //timer for hacking if ends fails.
    //works for every frame
    //time is in frames so it might be bad actually
    private IEnumerator HackTime(float countdownValue = 5)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            time.text = currCountdownValue.ToString("F2");
            yield return 0;
            currCountdownValue= currCountdownValue-0.01f;
        }
        if (currCountdownValue <= 0) { Debug.Log("failed because out of time"); time.text = 0.ToString(); Fail(); }
    }



    void Success() 
    {
       
        hackingstate.text = "hacking successful";
    }

    void Fail() 
    {
 
        hackingstate.text = "hacking failed";
    }

    Vector2 startnodepos= new Vector2(0,0);

    //controls agent node
    public void MoveNode(string str)
    {
       //Debug.Log("node array length:"+ nodeArray.GetLength(0) +","+ nodeArray.GetLength(1));
     
       switch (str)
            {
            case "up":
            
                if (startnodepos.y - 1 < 0) { Debug.Log("out of bounds");break; }//fail out of bounds
                else if (nodeArray[((int)startnodepos.x),((int)startnodepos.y)-1].GetComponent<NodeState>().State=="obstacle") { Debug.Log("hit obstacle");Fail(); break; }// fail hit block node
                else if (nodeArray[((int)startnodepos.x),((int)startnodepos.y) - 1].GetComponent<NodeState>().State == "exit") { Debug.Log("reached exit"); Success();}// successfully reached exit
                nodeArray[((int)startnodepos.x), ((int)startnodepos.y)].GetComponent<NodeState>().State = "obstacle";
                nodeArray[((int)startnodepos.x), ((int)startnodepos.y) - 1].GetComponent<NodeState>().State = "agent";
                startnodepos.y -= 1;
              

                break;
            case "down":
                if (startnodepos.y == nodeArray.GetLength(1) - 1) { Debug.Log("out of bounds"); break; }//fail out of bounds
                else if (nodeArray[((int)startnodepos.x), ((int)startnodepos.y) + 1].GetComponent<NodeState>().State == "obstacle") { Debug.Log("hit obstacle"); Fail(); break; }// fail hit block node
                else if (nodeArray[((int)startnodepos.x), ((int)startnodepos.y) + 1].GetComponent<NodeState>().State == "exit") { Debug.Log("reached exit"); Success(); }// successfully reached exit
                nodeArray[((int)startnodepos.x), ((int)startnodepos.y)].GetComponent<NodeState>().State = "obstacle";
                nodeArray[((int)startnodepos.x), ((int)startnodepos.y) + 1].GetComponent<NodeState>().State = "agent";
                startnodepos.y += 1;
                break;
            case "left":
                if (startnodepos.x - 1 < 0) { Debug.Log("out of bounds"); break; }//fail out of bounds
                else if (nodeArray[((int)startnodepos.x)-1, ((int)startnodepos.y)].GetComponent<NodeState>().State == "obstacle") { Debug.Log("hit obstacle"); Fail(); break; }// fail hit block node
                else if (nodeArray[((int)startnodepos.x) - 1, ((int)startnodepos.y)].GetComponent<NodeState>().State == "exit") { Debug.Log("reached exit"); Success(); }// successfully reached exit
                nodeArray[((int)startnodepos.x), ((int)startnodepos.y)].GetComponent<NodeState>().State = "obstacle";
                nodeArray[((int)startnodepos.x)-1, ((int)startnodepos.y)].GetComponent<NodeState>().State = "agent";
                startnodepos.x -= 1;
                break;
            case "right":
                if (startnodepos.x  == nodeArray.GetLength(0) - 1) { Debug.Log("out of bounds"); break; }//fail out of bounds
                else if (nodeArray[((int)startnodepos.x)+1, ((int)startnodepos.y)].GetComponent<NodeState>().State == "obstacle") { Debug.Log("hit obstacle"); Fail(); break; }// fail hit block node
                else if (nodeArray[((int)startnodepos.x) + 1, ((int)startnodepos.y)].GetComponent<NodeState>().State == "exit") { Debug.Log("reached exit"); Success(); }// successfully reached exit
                nodeArray[((int)startnodepos.x), ((int)startnodepos.y)].GetComponent<NodeState>().State = "obstacle";
                nodeArray[((int)startnodepos.x)+1, ((int)startnodepos.y) ].GetComponent<NodeState>().State = "agent";
                startnodepos.x += 1;
                break;
        }
       // Debug.Log("current agent location:" + startnodepos.x + ", " + startnodepos.y);

    }


   
    //puts obstacles
   GameObject[] Obstacler(GameObject[] fill,int obstaclenumber) 
    {
       
        for (int i = 0; i < nodeArray.GetLength(1); i++)
        {
            
            if (obstaclenumber > 0) { ChangeState(fill[i], "obstacle"); }
            else { ChangeState(fill[i], "empty");  }
            obstaclenumber -= 1;
        }
        return fill;
    }


    private string tempGO;
    //shuffles obstacles
    GameObject[] Shuffler(GameObject[] fill) 
    {
        for (int i = 0; i < fill.Length; i++)
        {
         
            int rnd = Random.Range(0, fill.Length);
            tempGO = fill[rnd].GetComponent<NodeState>().State;
            ChangeState(fill[rnd], fill[i].GetComponent<NodeState>().State);
            ChangeState(fill[i], tempGO);
        }
        return fill;
    }

    //changes states of nodes
    void ChangeState(GameObject obj,string state) 
    {
       // Debug.Log("changing state of: "+obj+"to: "+state);
        obj.GetComponent<NodeState>().State = state;
    }

   //get width of gamearray and put that width in temp array
    void fillArray(GameObject[] fill,int place) 
    {
        //Debug.Log("filling array: "+fill+"for place: "+place);
        for (int i=0;i<nodeArray.GetLength(1); i++) 
        {
            fill[i] = nodeArray[place, i];
        }
    }

    //makes gamearray ready
    void GameArray() 
    {
       
        int gamelength = nodeArray.GetLength(0);
        int gamewidth = nodeArray.GetLength(1);
        GameObject[] currentArray = new GameObject[gamewidth];
        GameObject[] nextArray = new GameObject[gamewidth];
        int pathcurrent=0;
        int pathnext;

        for(int k=0;k<gamelength-2; k++) 
        {
        if (k == 0) 
            {
                fillArray(currentArray,1);
                Shuffler(Obstacler(currentArray, Random.Range(gamewidth-1,gamewidth)));
                pathcurrent = Random.Range(0, gamewidth);
                ChangeState(currentArray[pathcurrent], "empty");
            }
            else 
            {
                pathnext = Random.Range(0, gamewidth);
                //create array
                gamewidth = nodeArray.GetLength(1);
                nextArray = new GameObject[gamewidth];
                fillArray(nextArray,k+1);

                //fill and shuffle array
                Shuffler(Obstacler(nextArray, Random.Range(gamewidth - 1, gamewidth)));
                ChangeState(nextArray[pathnext], "empty");

                //make way to pathnext from pathcurrent so it will always be possible to reach the end
                if (pathnext < pathcurrent) { for (int i = pathnext; i <= pathcurrent; i++) { ChangeState(nextArray[i], "empty"); } }
                else if (pathnext > pathcurrent) { for (int i = pathnext; i >= pathcurrent; i--) { ChangeState(nextArray[i], "empty"); } }

                //make nextarray currentarray and get new nextarray
                pathcurrent = pathnext;
                for (int i = 0; i < currentArray.Length; i++) { currentArray[i] = nextArray[i]; }
            }
       
        }


    }


}
}