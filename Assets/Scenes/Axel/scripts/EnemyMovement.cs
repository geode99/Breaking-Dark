using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;

    private Transform currentTarget;

    private SpriteRenderer enemySR;
    public bool FlipDir = false;

    //reference for destroying enemy
    public PlayerMovement playerMovementRefence;
    private bool isWizard = true;
    private bool isFireflyOn = false;
    public Animator enemyAnimator;
    public float delay = 0.5f;

    void Start()
    {
        currentTarget = pointA;
        enemySR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Move toward the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        //update vars
        isWizard = playerMovementRefence.isWizard;
        isFireflyOn = playerMovementRefence.isFireflyOn;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Switch target when reaching a trigger
        if (other.CompareTag("pointA"))
        {
            Debug.Log("wiks");
            currentTarget = pointB;
            enemySR.flipX = !FlipDir;
        }
        else if (other.CompareTag("pointB"))
        {
            Debug.Log("womps");
            currentTarget = pointA;
            enemySR.flipX = FlipDir;
        }

        //destroy enemy if firefly on
        else if (other.CompareTag("Player") && isWizard == false && isFireflyOn)
        {
            enemyAnimator.SetTrigger("dead");   
            Destroy(gameObject, delay);
        }
    }
}
