using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControllerTest : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speedH;
    [SerializeField] private float speedJ;
    private Animator anim;
    private bool grounded;
    private Vector2 movementInput = Vector2.zero;
    private void Awake()
    {
        //anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {

        movementInput = context.ReadValue<Vector2>();
        /*anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("fall", body.velocity.y < 0);
        anim.SetBool("grounded", grounded);*/
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        /*jumped = context.action.triggered;
        jumped = context.ReadValue<bool>();*/
        body.velocity = new Vector2(body.velocity.x, speedJ);
        //anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
