using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private float jumpForce;
    public float wizardJumpForce = 15.0f;
    public float fireflyJumpForce = 8.0f;
    private float _movement;
    private bool tab = false;

    private Rigidbody2D rb2d;
    public Rigidbody2D firefly;
    public Rigidbody2D wizard;

    private SpriteRenderer playerSR;
    public SpriteRenderer wizardSR;
    public SpriteRenderer fireflySR;

    private bool isWizard = true;
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
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>().x * speed;
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            rb2d.linearVelocityY = jumpForce;
        }
    }

    public void Switch(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            tab = !tab;
            Debug.Log("switched");
            if (tab)
            {
                rb2d = wizard;
                playerSR = wizardSR;
                jumpForce = wizardJumpForce;
                isWizard = true;
            }
            else if (tab == false)
            {
                rb2d = firefly;
                playerSR = fireflySR;
                jumpForce = fireflyJumpForce;
                isWizard = false;
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
}
