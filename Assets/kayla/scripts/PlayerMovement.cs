using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private float jumpForce;
    public float wizardJumpForce = 15.0f;
    public float fireflyJumpForce = 8.0f;
    private float _movement;
    public float dashForce = 10.0f;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = wizard;
        playerSR = wizardSR;
        jumpForce = wizardJumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocityX = _movement;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0)
        {
            playerSR.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            playerSR.flipX = true;
        }

        isGrounded= Physics2D.BoxCast(boxCastOrigin.position + boxCastOffset, boxCastSize, 0, Vector2.zero, 0, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCastOrigin.position + boxCastOffset, boxCastSize);
    }
   
    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>().x * speed;
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

    public void Down(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1 && isWizard == false)
        {
            rb2d.linearVelocityY = -jumpForce;
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
        if (ctx.ReadValue<float>() == 0)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            if (horizontalInput > 0)
            {
                Debug.Log("dash right");
                rb2d.linearVelocityX += dashForce;
            }
            else if (horizontalInput < 0)
            {
                Debug.Log("dash left");
                rb2d.linearVelocityX -= dashForce;
            }            
        }
    }
}
