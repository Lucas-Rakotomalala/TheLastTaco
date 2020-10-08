using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    public float moveSpeed;
    public float JumpForce;


    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private bool isAttacking;


    private Vector3 velocity= Vector3.zero;
    private float horizontalMovement;

    void Update()
    {
        InputButton();

        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        
       horizontalMovement = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;

       if (Input.GetButtonDown("Jump") && isGrounded)
       {
           isJumping = true;
       }


       MovePlayer(horizontalMovement);

       Flip(rb.velocity.x);

       float characterVelocity = Mathf.Abs(rb.velocity.x); 
       animator.SetFloat("Speed",characterVelocity);

        Attack();

        ResetValues();
    }
   
     void FixedUpdate()
    {
       MovePlayer(horizontalMovement);
    }


    void MovePlayer(float _horizontalMouvement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMouvement,rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity,targetVelocity,ref velocity, .05f);
    }

    void Attack()
    {
        if(isAttacking)
        {
            animator.SetTrigger("NinjaAttack");
            rb.velocity = Vector2.zero;
        }
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
}
