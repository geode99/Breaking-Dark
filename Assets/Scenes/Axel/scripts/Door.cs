using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;

    private BoxCollider2D CoL;
    public SpriteRenderer sr;

    private void Awake()
    {
        CoL = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();

        if (isOpen)
        {
            CoL.isTrigger = true;
        }
        else
        {
            CoL.isTrigger = false;   
        }
    }
    public void Update()
    {
        if (isOpen)
        {
            sr.color = new Color(1f, 1f, 1f, 0.3f);
        }
        else
        {
            sr.color = new Color(1f, 1f, 1f, 1f);
        }
    }
    public void open()
    {
        isOpen = true;
        CoL.isTrigger = true;
    }
    
    public void close()
    {
        isOpen = false;
        CoL.isTrigger = false;
    }

    public void toggle()
    {
        isOpen = !isOpen;
        CoL.isTrigger = isOpen;
    }
}
