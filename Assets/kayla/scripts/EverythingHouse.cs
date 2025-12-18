using UnityEngine;
using UnityEngine.InputSystem;

public class EverythingHouse : MonoBehaviour
{
    public HouseControls HouseControlsReference;
    private bool inHouse = false;
    public Canvas houseCanvas;
    public Canvas pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        houseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        inHouse = HouseControlsReference.inHouse;
    }

    public void EscapeHouse(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1 && inHouse == true)
        {
            houseCanvas.enabled = false;
            inHouse = false;
        }
        if (ctx.ReadValue<float>() == 1 && inHouse == false)
        {
            pauseMenu.enabled = true;
        }
    }

    public void Pause(InputAction.CallbackContext ctx)
    {
    }
}
