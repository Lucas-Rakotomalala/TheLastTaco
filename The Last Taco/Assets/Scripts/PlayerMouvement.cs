using UnityEngine;
using System.Collections;

public class PlayerMouvement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;


    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private bool isAttacking;


    private Vector3 velocity= Vector3.zero;
    private float horizontalMovement;

    void Update()
    {
        InputButton();
        
       horizontalMovement = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;

       if (Input.GetKeyDown(SpacebarKey())&& isGrounded)
       {
           isJumping = true;
       }

       Flip(rb.velocity.x);

       float characterVelocity = Mathf.Abs(rb.velocity.x); 
       animator.SetFloat("Speed",characterVelocity);

        Attack();

        ResetValues();
    }
   
     void FixedUpdate()
    {
       isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, collisionLayers);
       MovePlayer(horizontalMovement);
    }


    void MovePlayer(float _horizontalMouvement)
    {
        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
        else
        {
            Vector3 targetVelocity = new Vector2(_horizontalMouvement,rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity,targetVelocity,ref velocity, .05f);
        }
    }

    void Attack()
    {
        if(isAttacking)
        {
            animator.SetTrigger("NinjaAttack");
            rb.velocity = Vector2.zero;
        }
    }

    public static KeyCode SpacebarKey()
    {
    if (Application.isEditor) return KeyCode.O;
    else return KeyCode.Space;
    }

    void InputButton()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isAttacking = true;
        }
    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        } 
    }

    private void ResetValues()
    {
        isAttacking = false;
    }

      private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
