using Unity.Properties;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Movement speed of the player")]
    public float moveSpeed = 5.0f;
    [Tooltip("Jump force applied to the player")]
    public float jumpForce = 7.0f;
    [Tooltip("Sprint speed of the player")]
    public float sprintSpeed = 10.0f;
    [Tooltip("Climb force applied to the player")]
    private float currentMoveSpeed = 0.0f;

    public Animator animator;

    private Rigidbody2D playerRB;
    private float _movement;
    private BoxCollider2D boxColl;
    [SerializeField] LayerMask jumpableGround;
    [SerializeField] private SpriteRenderer playerSR;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();
        playerSR = GetComponent<SpriteRenderer>();

        currentMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.linearVelocityX = _movement;
        isClimbable = climbControlReference.isClimbing;
        animator.SetFloat("speed", Mathf.Abs(_movement));
        if (isGrounded() == true)
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isGliding", false);
            animator.SetBool("canSlide", false);
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0)
        {
            playerSR.flipX = true;
        }
        else if (horizontalInput < 0)
        {
            playerSR.flipX = false;
        }
    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>().x * currentMoveSpeed;
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        animator.SetBool("isJump", true);
        if (ctx.ReadValue<float>() == 1 && isGrounded())
        {
            playerRB.linearVelocityY = jumpForce;
        }
    }
    public void Sprint(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
        {
            currentMoveSpeed = moveSpeed;
            return;
        }
        currentMoveSpeed = sprintSpeed;
    }

    public void Switch()
    {
        debug.Log("Switching Movement Scheme");
    }
}
