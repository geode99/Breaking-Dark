using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ButtonTrigger : MonoBehaviour
{
    public BoxCollider2D door;
    public SpriteRenderer doorSR;

    private Light2D flame;
    public PlayerMovement playerMovementReference;
    private bool isFireflyOn = false;
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


    public void LanternOn()
    {
        if (isFireflyOn)
        {
            door.isTrigger = true;
            doorSR.color = new Color(1f, 1f, 1f, 0.1f);
            flame.enabled = true;
        }
    }

    public void ButtonOn()
    {
        door.isTrigger = true;
        doorSR.color = new Color(1f, 1f, 1f, 0.1f);
    }
}
