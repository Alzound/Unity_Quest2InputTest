using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [Header("Input System")]
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction PrimaryButtonR, SecondaryButtonR, GripButtonR, StartButtonR, TriggerButtonR;
    private InputAction PrimaryButtonL, SecondaryButtonL, GripButtonL, StartButtonL, TriggerButtonL;

    [Header("References")]
    public LeftCollider leftCollider; 
    public RightCollider rightCollider;

    private void Awake()
    {
        //Right
        PrimaryButtonR = playerInput.actions["PrimaryButtonR"];
        SecondaryButtonR = playerInput.actions["SecondaryButtonR"];
        GripButtonR = playerInput.actions["GripButtonR"];
        StartButtonR = playerInput.actions["StartButtonR"];
        TriggerButtonR = playerInput.actions["TriggerButtonR"];
        //Left
        PrimaryButtonL = playerInput.actions["PrimaryButtonL"];
        SecondaryButtonL = playerInput.actions["SecondaryButtonL"];
        GripButtonL = playerInput.actions["GripButtonL"];
        StartButtonL = playerInput.actions["StartButtonL"];
        TriggerButtonL = playerInput.actions["TriggerButtonL"];
    }
    private void OnEnable()
    {
        //RIGHT
        //Performed Actions.
        PrimaryButtonR.performed += PrimaryActionR;
        SecondaryButtonR.performed += SecondaryActionR;
        //GripButtonR.performed += GripActionR;
        StartButtonR.performed += StartActionR;
        TriggerButtonR.performed += TriggerActionR;
        //Canceled Actions
        PrimaryButtonR.canceled += PrimaryActionR;
        SecondaryButtonR.canceled += SecondaryActionR;
        //GripButtonR.canceled += GripActionR;
        StartButtonR.canceled += StartActionR;
        TriggerButtonR.canceled += TriggerActionR;

        //LEFT
        //Performed Actions.
        PrimaryButtonL.performed += PrimaryActionL;
        SecondaryButtonL.performed += SecondaryActionL;
        //GripButtonL.performed += GripActionL;
        StartButtonL.performed += StartActionL;
        TriggerButtonL.performed += TriggerActionL;
        //Canceled Actions
        PrimaryButtonL.canceled += PrimaryActionL;
        SecondaryButtonL.canceled += SecondaryActionL;
        //GripButtonL.canceled += GripActionL;
        StartButtonL.canceled += StartActionL;
        TriggerButtonL.canceled += TriggerActionL;
    }
    private void OnDisable()
    {
        //RIGHT
        PrimaryButtonR.performed -= PrimaryActionR;
        SecondaryButtonR.performed -= SecondaryActionR;
        //GripButtonR.performed -= GripActionR;
        StartButtonR.performed -= StartActionR;
        TriggerButtonR.performed -= TriggerActionR;

        PrimaryButtonR.canceled -= PrimaryActionR;
        SecondaryButtonR.canceled -= SecondaryActionR;
        //GripButtonR.canceled -= GripActionR;
        StartButtonR.canceled -= StartActionR;
        TriggerButtonR.canceled -= TriggerActionR;

        //LEFT
        PrimaryButtonL.performed -= PrimaryActionL;
        SecondaryButtonL.performed -= SecondaryActionL;
        //GripButtonL.performed -= GripActionL;
        StartButtonL.performed -= StartActionL;
        TriggerButtonL.performed -= TriggerActionL;

        PrimaryButtonL.canceled -= PrimaryActionL;
        SecondaryButtonL.canceled -= SecondaryActionL;
        //GripButtonL.canceled -= GripActionL;
        StartButtonL.canceled -= StartActionL;
        TriggerButtonL.canceled -= TriggerActionL;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void PrimaryActionR(InputAction.CallbackContext context)
    {
        Debug.Log("primary");
    }
    private void SecondaryActionR(InputAction.CallbackContext context)
    {
        Debug.Log("secondary");
    }

    private void StartActionR(InputAction.CallbackContext context)
    {
        Debug.Log("start");
    }
    private void TriggerActionR(InputAction.CallbackContext context)
    {
        Debug.Log("trigger");
    }


    private void PrimaryActionL(InputAction.CallbackContext context)
    {
        Debug.Log("primary");
    }
    private void SecondaryActionL(InputAction.CallbackContext context)
    {
        Debug.Log("secondary");
    }
    private void StartActionL(InputAction.CallbackContext context)
    {
        Debug.Log("start");
    }
    private void TriggerActionL(InputAction.CallbackContext context)
    {
        Debug.Log("trigger");
    }
}
