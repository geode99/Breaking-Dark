using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lanterns : MonoBehaviour
{
    private Light2D flame;
    public PlayerMovement playerMovementReference;
    private bool isFireflyOn = false;
    public bool triggered = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flame = GetComponent<Light2D>();
        flame.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        isFireflyOn = playerMovementReference.isFireflyOn;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && isFireflyOn)
        {
            flame.enabled = true;
            triggered = true;
        }
    }
}
