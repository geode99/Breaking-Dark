using Unity.Properties;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Tooltip("Movement speed of the player")]
    public float moveSpeed = 5.0f;
    [Tooltip("Climb force applied to the player")]
    private float currentMoveSpeed = 0.0f;
    private Rigidbody2D playerRB;
    private float _movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        currentMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.linearVelocityX = _movement;
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>().x * currentMoveSpeed;
    }

    public void Switch()
    {
        debug.Log("Switching Movement Scheme");
    }
}
