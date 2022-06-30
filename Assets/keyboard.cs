using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Hackingminigame;

public class keyboard : MonoBehaviour
{
    // a simple script to control
    public Hacking hackingobject;
    private void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame) { hackingobject.GetComponent<Hacking>().MoveNode("left"); }
        else if (Keyboard.current.sKey.wasPressedThisFrame) { hackingobject.GetComponent<Hacking>().MoveNode("down"); }
        else if (Keyboard.current.dKey.wasPressedThisFrame) { hackingobject.GetComponent<Hacking>().MoveNode("right"); }
        else if (Keyboard.current.wKey.wasPressedThisFrame) { hackingobject.GetComponent<Hacking>().MoveNode("up"); }
        else if (Keyboard.current.rKey.wasPressedThisFrame) { hackingobject.GetComponent<Hacking>().StartMinigame(); }
        else if (Keyboard.current.hKey.wasPressedThisFrame) { }
        else if (Keyboard.current.jKey.wasPressedThisFrame) { }
        else if (Keyboard.current.kKey.wasPressedThisFrame) { }
        else if (Keyboard.current.lKey.wasPressedThisFrame) { }
        else if (Keyboard.current.tKey.wasPressedThisFrame) { hackingobject.GetComponent<Hacking>().IsTimed = !hackingobject.GetComponent<Hacking>().IsTimed; }



    }


}
