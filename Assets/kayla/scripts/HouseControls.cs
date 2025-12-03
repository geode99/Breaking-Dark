using UnityEngine;
using UnityEngine.InputSystem;

public class HouseControls : MonoBehaviour
{
    public bool M = false;
    public bool D = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MTrigger(InputAction.CallbackContext ctx)
    {
        M = true;
        if (ctx.ReadValue<float>() == 0)
        {
            M = false;
        }
    }

    public void DTrigger(InputAction.CallbackContext ctx)
    {
        D = true;
        if (ctx.ReadValue<float>() == 0)
        {
            D = false;
        }
    }
}
