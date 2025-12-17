using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;

    private Transform currentTarget;

    private SpriteRenderer enemySR;

    void Start()
    {
        currentTarget = pointA;
        enemySR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Move toward the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        //flip based on move direction
        if (transform.position.x > 0)
        {
            enemySR.flipX = false;
        }
        else if (transform.position.x < 0)
        {
            enemySR.flipX = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Switch target when reaching a trigger
        if (other.CompareTag("pointA"))
        {
            Debug.Log("wiks");
            currentTarget = pointB;
        }
        else if (other.CompareTag("pointB"))
        {
            Debug.Log("womps");
            currentTarget = pointA;
        }
    }
}
