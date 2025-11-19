using UnityEngine;

public class WizardBoxCollider : MonoBehaviour
{
    private BoxCollider2D boxColl;
    [SerializeField] LayerMask jumpableGround;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
