using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;

    private Transform currentTarget;

    void Start()
    {
        currentTarget = pointB;
    }

    void Update()
    {
        if (this.gameObject.transform == pointB)
        {
            pointB = pointA.transform;
        }


        // Move toward the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Switch target when reaching a trigger
        if (other.CompareTag("pointA"))
        {
            Debug.Log("woks");
            currentTarget = pointB;
        }
        else if (other.CompareTag("pointB"))
        {
            pointB = pointA;
        }
    }
}
