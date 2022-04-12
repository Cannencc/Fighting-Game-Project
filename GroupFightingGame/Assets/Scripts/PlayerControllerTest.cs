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
    private bool grounded;
    private float movementInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        if(grounded)
            movementInput = context.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        /*jumped = context.action.triggered;
        jumped = context.ReadValue<bool>();*/
        Debug.Log("Grounded Status: " + grounded);
        if(grounded)
        {
            body.velocity = new Vector2(body.velocity.x, speedJ);
            grounded = false;
        }

        //anim.SetTrigger("jump");
        //grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
    void Update()
    {
        Debug.Log("Grounded Status: " + grounded);
        body.velocity = new Vector2(speedH * movementInput, body.velocity.y);
    }
}
