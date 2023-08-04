using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using Oculus.Haptics; 

public class RightCollider : MonoBehaviour
{
    [Header("Haptics")]
    // Assign both clips in the Unity editor
    public HapticClip clip1;
    private HapticClipPlayer player;

    [Header("Propiedades")]
    public bool isRight, onUse;
    private Vector3 originalPos; 
    [Header("Input System")]
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction GripButtonR;

    private void Awake()
    {
        player = new HapticClipPlayer(clip1);
        GripButtonR = playerInput.actions["GripButtonR"];
    }
    private void Start()
    {

    }
    private void OnEnable()
    {
        GripButtonR.performed += GripActionR;
        GripButtonR.canceled += GripActionR;
    }
    private void OnDisable()
    {
        GripButtonR.performed -= GripActionR;
        GripButtonR.canceled -= GripActionR;
    }
    private void GripActionR(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isRight = true;
        }
        if (context.canceled) 
        {
            isRight = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable"))
        {
            PlayHapticClipR(); 
        }
    }
    public void PlayHapticClipR()
    {
        player.Play(HapticInstance.Hand.Right);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Grabable") && isRight && !onUse)
        {
            onUse = true;
            other.gameObject.transform.position = this.transform.position;
        }
        else
        {
            onUse = false;
        }
    }
}
