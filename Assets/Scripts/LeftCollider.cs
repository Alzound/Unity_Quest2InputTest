using Oculus.Haptics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftCollider : MonoBehaviour
{
    [Header("Haptics")]
    // Assign both clips in the Unity editor
    public HapticClip clip1;
    private HapticClipPlayer player;

    [Header("Propiedades")]
    public bool isLeft, onUse;
    private Vector3 originalPos;
    [Header("Input System")]
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction GripButtonL;


    private void Awake()
    {
        player = new HapticClipPlayer(clip1);
        GripButtonL = playerInput.actions["GripButtonL"];
    }
    private void OnEnable()
    {
        GripButtonL.performed += GripActionL;
        GripButtonL.canceled += GripActionL;
    }
    private void OnDisable()
    {
        GripButtonL.performed -= GripActionL;
        GripButtonL.canceled -= GripActionL;
    }

    private void GripActionL(InputAction.CallbackContext context)
    {
        Debug.Log("grip");
        if (context.performed)
        {
            isLeft = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable"))
        {
            PlayHapticClipL();
        }
    }
    public void PlayHapticClipL()
    {
        player.Play(HapticInstance.Hand.Left);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Grabable") && isLeft && !onUse)
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
