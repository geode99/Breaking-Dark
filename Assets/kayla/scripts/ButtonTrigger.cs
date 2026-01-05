using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ButtonTrigger : MonoBehaviour
{
    public BoxCollider2D door;
    public SpriteRenderer doorSR;
    private SpriteRenderer selfSR;

    private Light2D flame;
    public PlayerMovement playerMovementReference;
    private bool isFireflyOn = false;

    //text
    public TextMeshProUGUI openedDoorText;
    private Color Color;
    private Color resetColor;
    public float fadeDuration = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flame = GetComponent<Light2D>();
        flame.enabled = false;

        openedDoorText.enabled = false;
        Color = openedDoorText.color;
        resetColor = new Color(Color.r, Color.g, Color.b, 1f);
        openedDoorText.color = resetColor;
        selfSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isFireflyOn = playerMovementReference.isFireflyOn;
    }

    public void FadeOut(TextMeshProUGUI text)
    {
        text.CrossFadeAlpha(1f, 0f, false);
        text.CrossFadeAlpha(0f, fadeDuration, false);
    }

    public void LanternOn()
    {
        if (isFireflyOn)
        {
            flame.enabled = true;
            if (door != null && doorSR != null)
            {
                door.isTrigger = true;
                doorSR.color = new Color(0.074f, 0.035f, 0.141f, 0.5f);
                openedDoorText.enabled = true;
                FadeOut(openedDoorText);
                openedDoorText.color = resetColor;
            }

        }
    }

    public void ButtonOn()
    {
        door.isTrigger = true;
        doorSR.color = new Color(0.074f, 0.035f, 0.141f, 0.5f);
        selfSR.color = new Color(0.267f, 0.257f, 0.301f, 0.7f);

        openedDoorText.enabled = true;
        FadeOut(openedDoorText);
        openedDoorText.color = resetColor;
    }
}
