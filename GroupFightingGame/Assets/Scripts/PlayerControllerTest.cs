using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControllerTest : MonoBehaviour
{
    public Rigidbody2D body;
    [SerializeField] private float speedH;
    [SerializeField] private float speedJ;
    private Animator anim;
    private bool grounded, stop = false;
    private float movementInput;
    private InputActionReference actionRef;

    private void OnEnable()
    {
        actionRef.action.Enable();
    }
    private void OnDisable()
    {
        actionRef.action.Disable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if(grounded)
            movementInput = context.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {

        Debug.Log("Grounded Status: " + grounded);
        if(grounded)
        {
            body.velocity = new Vector2(body.velocity.x, speedJ);
            grounded = false;
        }

    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                Debug.Log("Performed");
                break;
            case InputActionPhase.Started:
                Debug.Log("Started");
                OnJump(context);
                break;
            case InputActionPhase.Canceled:
                Debug.Log("Canceled");
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            movementInput = 0f;
        }

    }

    void Update()
    {
        //Debug.Log("Grounded Status: " + grounded);
        body.velocity = new Vector2(speedH * movementInput, body.velocity.y);
    }
}
