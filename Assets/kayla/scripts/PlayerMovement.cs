using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    [Header("editable movement values")]
    public float speed = 5.0f;
    private float jumpForce;
    public float wizardJumpForce = 15.0f;
    public float fireflyJumpForce = 8.0f;
    private float _movement;
    private Vector2 _movementVector;
    public float dashForce = 10.0f;
    private float currentMovementSpeed;

    [Header("rigid bodies")]
    private Rigidbody2D rb2d;
    public Rigidbody2D firefly;
    public Rigidbody2D wizard;

    [Header("rendering")]
    private SpriteRenderer playerSR;
    public SpriteRenderer wizardSR;
    public SpriteRenderer fireflySR;
    public Animator wizAnimator;
    public Animator ffAnimator;
    
    [Header("light")]
    public Light2D fireflylight;

    [Header("jump related")]
    public Transform boxCastOrigin;
    public Vector3 boxCastOffset;
    public Vector2 boxCastSize;
    public LayerMask groundLayer;

    //HUD Stuff
    [Header("HUD")]
    public Animator Hud;
    public Canvas pauseMenu;

    [Header("health")]
    public PlayerHealths hp;
    public float drainAmount = 1f;

    [Header("ignore all these  DO NOT EDIT")]
    public bool isWizard = true;
    public bool isGrounded;
    public bool isFireflyOn = false;
    private bool isDashing = false;

    //Audio stuff
    AudioManager audioManager;

    // queued input flags (callbacks only set these)
    private bool queuedJump = false;
    private bool queuedDashInput = false;
    private bool prevQueuedDashInput = false;

    // store raw move input so movement scaling happens after dash is processed
    private Vector2 movementInput = Vector2.zero;

    private void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();  
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = wizard;
        playerSR = wizardSR;
        jumpForce = wizardJumpForce;
        currentMovementSpeed = speed;
        pauseMenu.enabled = false;
        fireflylight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Process queued inputs first (priority ordering happens here)
        ProcessQueuedInputs();

        // Now compute movement values using the (possibly) updated currentMovementSpeed.
        // This ensures dash (which modifies currentMovementSpeed) is applied before movement scaling.
        if (isWizard)
        {
            _movement = movementInput.x * currentMovementSpeed;
        }
        else
        {
            _movementVector = movementInput * currentMovementSpeed;
        }

        rb2d.linearVelocityX = _movement;
        Hud.SetBool("IsWiz", isWizard);
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.BoxCast(boxCastOrigin.position + boxCastOffset, boxCastSize, 0, Vector2.zero, 0, groundLayer);
        
        if (!isWizard && isFireflyOn)
        {
            hp.FireflyHealth -= Time.deltaTime * drainAmount;
        }
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

        if (rb2d.linearVelocityY <= 0)
        {
            wizAnimator.SetBool("isJump", false);
            wizAnimator.SetBool("isFall", true);
        }
        if (isGrounded)
        {
            wizAnimator.SetBool("isFall", false);
        }

        if (isDashing == false)
        {
            currentMovementSpeed = speed;
        }

        if(isWizard == false)
        {
            rb2d.linearVelocity = _movementVector;
        }

        if (pauseMenu.enabled)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    }

    private void ProcessQueuedInputs()
    {
        // Priority: Jump > Dash
        if (queuedJump)
        {
            // consume the jump request immediately
            queuedJump = false;
            if (isGrounded == true && isWizard)
            {
                rb2d.linearVelocityY = jumpForce;
                wizAnimator.SetBool("isJump", true);
                audioManager.PlaySFX(audioManager.jump);
            }
        }

        // Handle dash input state changes after jump (so jump wins when both happen same frame)
        if (queuedDashInput && !prevQueuedDashInput)
        {
            // dash started
            isDashing = true;
            currentMovementSpeed += dashForce;
            if (isWizard)
            {
                wizAnimator.SetBool("isDashing", true);
                audioManager.PlaySFX(audioManager.dash);
            }
            else
            {
                ffAnimator.SetBool("isDashing", true);
                audioManager.PlaySFX(audioManager.dash);
            }
        }
        else if (!queuedDashInput && prevQueuedDashInput)
        {
            // dash ended
            isDashing = false;
            wizAnimator.SetBool("isDashing", false);
            ffAnimator.SetBool("isDashing", false);
            // reset movement speed (keep simple: reset to base speed)
            currentMovementSpeed = speed;
        }

        prevQueuedDashInput = queuedDashInput;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCastOrigin.position + boxCastOffset, boxCastSize);
    }

    // Callbacks now only record intent (no immediate action). Update() processes them in priority order.
    public void Dash(InputAction.CallbackContext ctx)
    {
        queuedDashInput = ctx.ReadValue<float>() == 1;
    }
    
    public void Move(InputAction.CallbackContext ctx)
    {
        // record raw input; scaling is deferred to Update so dash can modify speed first
        movementInput = ctx.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            queuedJump = true;
        }
    }

    public void Switch(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
        {
            wizAnimator.SetTrigger("Switch");
            audioManager.PlaySFX(audioManager.change);

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
            fireflylight.enabled = !fireflylight.enabled;
            audioManager.PlaySFX(audioManager.fireflylight);
        }
    }

    public void Pause(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            pauseMenu.enabled = true;
        }
    }

}
