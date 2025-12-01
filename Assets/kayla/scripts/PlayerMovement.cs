using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private float jumpForce;
    public float wizardJumpForce = 15.0f;
    public float fireflyJumpForce = 8.0f;
    private float _movement;
    private Vector2 _movementVector;
    public float dashForce = 10.0f;
    private float currentMovementSpeed;

    private Rigidbody2D rb2d;
    public Rigidbody2D firefly;
    public Rigidbody2D wizard;

    private SpriteRenderer playerSR;
    public SpriteRenderer wizardSR;
    public SpriteRenderer fireflySR;

    public bool isWizard = true;
    public bool isGrounded;

    public Transform boxCastOrigin;
    public Vector3 boxCastOffset;
    public Vector2 boxCastSize;
    public LayerMask groundLayer;

    public bool isFireflyOn = true;
    private bool isDashing = false;

    //HUD Stuff
    public Animator Hud;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = wizard;
        playerSR = wizardSR;
        jumpForce = wizardJumpForce;
        currentMovementSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocityX = _movement;
        Hud.SetBool("IsWiz", isWizard);
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0)
        {
            playerSR.flipX = false;
            //isFacingRight = true;
        }
        else if (horizontalInput < 0)
        {
            playerSR.flipX = true;
            //isFacingRight = false;
        }

        isGrounded= Physics2D.BoxCast(boxCastOrigin.position + boxCastOffset, boxCastSize, 0, Vector2.zero, 0, groundLayer);

        if(isDashing == false)
        {
            currentMovementSpeed = speed;
        }

        if(isWizard == false)
        {
            rb2d.linearVelocity = _movementVector;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCastOrigin.position + boxCastOffset, boxCastSize);
    }
   
    public void Move(InputAction.CallbackContext ctx)
    {
        if (isWizard)
        {
            _movement = ctx.ReadValue<Vector2>().x * currentMovementSpeed;
        }
        if (isWizard == false)
        {
            _movementVector = ctx.ReadValue<Vector2>() * currentMovementSpeed;
        }
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            if (isGrounded == true || isWizard == false)
            {
                rb2d.linearVelocityY = jumpForce;
            }
        }
    }

    public void Switch(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
        {
            isWizard = !isWizard;
            if (isWizard)
            {
                Debug.Log("wizard");
                rb2d = wizard;
                playerSR = wizardSR;
                jumpForce = wizardJumpForce;     
            }
            else if (isWizard == false)
            {
                Debug.Log("firefly");
                rb2d = firefly;
                playerSR = fireflySR;
                jumpForce = fireflyJumpForce;
            }
        }
    }

    public void OnOff(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
        {
            isFireflyOn = !isFireflyOn;
        }
    }

    public void Dash(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            isDashing = true;
            currentMovementSpeed += dashForce;
        }
        if (ctx.ReadValue<float>() == 0)
        {            
            isDashing = false;
        }
    }
}
