using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;

    private Transform currentTarget;

    void Start()
    {
        currentTarget = pointA;
    }

    void Update()
    {
        // Move toward the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
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
