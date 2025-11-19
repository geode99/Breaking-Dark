using UnityEngine;

public class WizardBoxCollider : MonoBehaviour
{
    public bool isJumping = false;
    private Rigidbody2D rb2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void oncollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].point.y < transform.position.y)
        {
            isJumping = false;
        }
    }
}
