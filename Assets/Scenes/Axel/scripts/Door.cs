using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;

    private BoxCollider2D CoL;

    private void Awake()
    {
        CoL = GetComponent<BoxCollider2D>();

        if (isOpen)
        {
            CoL.isTrigger = true;
        }
        else
        {
            CoL.isTrigger = false;
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
