using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speedH;
    [SerializeField] private float speedJ;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speedH, body.velocity.y);


        if(Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            Jump();
        }

        /*anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("fall", body.velocity.y < 0);
        anim.SetBool("grounded", grounded);*/
    }

    private void Jump()
    {
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
