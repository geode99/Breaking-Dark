using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    private Rigidbody2D rb2d;
    private float _movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocityX = _movement;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>().x *speed; 
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() ==1)
        {
            rb2d.linearVelocityY = jumpForce;
        }
    }

    public void Switch(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            Debug.Log("switched");
        }
    }
}
