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
    //Light Script
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
    public HouseTriggerZone HouseTriggerZoneReference;
    private bool inHouse = false;
    public Canvas houseCanvas;

    //Health Script
    [Header("health")]
    public PlayerHealths hp;
    public float drainAmount = 1f;

    [Header("ignore all these  DO NOT EDIT")]
    public bool isWizard = true;
    public bool isGrounded;
    public bool isFireflyOn = true;
    private bool isDashing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = wizard;
        playerSR = wizardSR;
        jumpForce = wizardJumpForce;
        currentMovementSpeed = speed;
        pauseMenu.enabled = false;
        houseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        inHouse = HouseTriggerZoneReference.inHouse;
        if (!isWizard && isFireflyOn) { 
            hp.FireflyHealth -= Time.deltaTime * drainAmount;
        }
        ;
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
        if (rb2d.linearVelocityY <= 0)
        {
            wizAnimator.SetBool("isJump", false);
        }

        if(isDashing == false)
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
        }
        else
        {
            Time.timeScale = 1f;
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
                wizAnimator.SetBool("isJump", true);
            }
        }
    }

    public void Switch(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
        {
            wizAnimator.SetBool("isSwitching", true);
            wizAnimator.SetBool("isSwitching", false);
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
        }
    }

    public void Dash(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            isDashing = true;
            currentMovementSpeed += dashForce;
            if (isWizard)
            {
                wizAnimator.SetBool("isDashing", true);
            }
            else
            {
                ffAnimator.SetBool("isDashing", true);
            }
        }
        if (ctx.ReadValue<float>() == 0)
        {            
            isDashing = false;
            wizAnimator.SetBool("isDashing", false);
            ffAnimator.SetBool("isDashing", false);
        }
    }

    public void Pause(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1 && inHouse == false)
        {
            pauseMenu.enabled = true;
        }
    }

    public void EscapeHouse(InputAction.CallbackContext ctx)
        {
        if (ctx.ReadValue<float>() == 1 && inHouse == true)
        {
            houseCanvas.enabled = false;
        }
    }
}
