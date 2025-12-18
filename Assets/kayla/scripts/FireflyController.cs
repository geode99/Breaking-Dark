using UnityEngine;

public class FireflyController : MonoBehaviour
{
    public Animator fireflyAnimator;
    public bool isFireflyOn = true;
    public PlayerMovement playerMovementReference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isFireflyOn = playerMovementReference.isFireflyOn;
        fireflyAnimator.SetBool("isOn", isFireflyOn);
    }
}
