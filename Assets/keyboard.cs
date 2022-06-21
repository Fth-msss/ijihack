using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class keyboard : MonoBehaviour
{
    private PlayerInput playerInput;
    private Ijihack playerControls;
    private InputAction navigateAction;

    private void Awake()
    {
        playerControls = new Ijihack();
        playerInput = GetComponent<PlayerInput>();
        navigateAction = playerInput.actions["Navigate"];
       // jumpAction = playerInput.actions["Jump"];
      //  jumpAction.ReadValue<float>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.UI.Navigate.performed -= Movin;
    }

    private void Start()
    {
        playerControls.UI.Navigate.performed += Movin;
    }

    private void Movin(InputAction.CallbackContext context) 
    {
        context.ReadValue<Vector2>();
        Debug.Log(context.ReadValue<Vector2>());
    }

    private void Update()
    {
        Vector2 move = playerControls.UI.Navigate.ReadValue<Vector2>();
       // Debug.Log(navigateAction.ReadValue<Vector2>());
        playerControls.UI.Navigate.ReadValue<Vector2>();
    }


    ////what is this?

    //GameObject asdf;
    //Keyboard kb;
    //public InputActionAsset controls;

    //void MoveHackNode(string asd) 
    //{
    //    asdf.GetComponent<Hacking>().MoveNode(asd);
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    kb = InputSystem.GetDevice<Keyboard>();
    //    if (kb.spaceKey.wasPressedThisFrame) 
    //    {
    //        Shoot();
    //    }
    //}
}
