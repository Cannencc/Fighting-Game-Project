using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControllerTest : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody2D body;
    [SerializeField] private float speedTowards;
    [SerializeField] private float speedAway;
    [SerializeField] private float speedJump;
    private Animator anim;
    private bool grounded, stop = false, lightAttack = false;
    private float movementInput;
    private InputActionReference actionRef;
    public int maxHealth = 100;
    public static int P1currentHealth;
    public static int P2currentHealth;
    public HealthBar P1healthBar;
    public HealthBar P2healthBar;
    public Transform attackHitBox;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;



    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        P1currentHealth = maxHealth;
        P2currentHealth = maxHealth;

        P1healthBar.SetMaxHealth(maxHealth);
        P2healthBar.SetMaxHealth(maxHealth);
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
            body.velocity = new Vector2(body.velocity.x, speedJump);
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

    public void OnSpacebar(InputAction.CallbackContext context)
    {
        if(context.performed)
            P1TakeDamage(10);
    }

    public void OnRightShift(InputAction.CallbackContext context)
    {
        if (context.performed)
            P2TakeDamage(10);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Attack");
            playerAnim.SetTrigger("lightAttack");
            body.transform.position += body.transform.forward * Time.deltaTime * 5f;
        }
        Collider2D[] hitOpponents = Physics2D.OverlapCircleAll(attackHitBox.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitOpponents)
        {
            P2TakeDamage(10);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackHitBox == null)
            return;
        Gizmos.DrawWireSphere(attackHitBox.position, attackRange);
    }
    void Update()
    {
        //Debug.Log("Grounded Status: " + grounded);
        if(movementInput < 0)
            body.velocity = new Vector2(speedAway * movementInput, body.velocity.y);
        else
            body.velocity = new Vector2(speedTowards * movementInput, body.velocity.y);

        playerAnim.SetFloat("walkDirection", body.velocity.x);
    }

    void P1TakeDamage(int damage)
    {
        P1currentHealth -= damage;
        P1healthBar.SetHealth(P1currentHealth);
        Debug.Log("OUCH");

    }

    void P2TakeDamage(int damage)
    {
        P2currentHealth -= damage;
        P2healthBar.SetHealth(P2currentHealth);

    }
}
