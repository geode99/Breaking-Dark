using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HouseControls : MonoBehaviour
{
    public bool M = false;
    public bool D = false;

    public bool inHouseZone = false;
    public HouseTriggerZone HouseTriggerZoneReference;
    public bool inHouse = false;
    public Canvas houseCanvas;
    public Collectables collectablesReference;
    public List<Image> collectedItems;
    public List<Image> collectableObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Image item in collectableObjects)
        {
            item.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        collectedItems = collectablesReference.collectedItems;
        inHouse = HouseTriggerZoneReference.inHouse;
        inHouseZone = HouseTriggerZoneReference.inHouseZone;

        if (M && D && inHouseZone)
        {
            Debug.Log("In House Zone and M pressed");
            houseCanvas.enabled = true;
            inHouse = true;
            ShowCollection();
        }
    }

    private void ShowCollection()
    {
        //Debug.Log("Collected Items:");
        foreach (Image item in collectedItems)
        {
            //Debug.Log(item);
            item.enabled = true;
        }
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
