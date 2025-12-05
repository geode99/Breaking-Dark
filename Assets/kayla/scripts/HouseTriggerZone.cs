using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using static UnityEditor.Rendering.CoreEditorDrawer<TData>;

public class HouseTriggerZone : MonoBehaviour
{
    public bool inHouseZone = false;
    public bool M = false;
    public bool D = false;
    public HouseControls HouseControlsReference;
    public bool inHouse = false;
    public Canvas houseCanvas;
    public Collectables collectablesReference;
    public List<string> collectedItems;
    public List<GameObject> collectedObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        collectedItems = collectablesReference.collectedItems;
        M = HouseControlsReference.M;
        D = HouseControlsReference.D;
        if (M && D && inHouseZone)
        {
            Debug.Log("In House Zone and M pressed");
            houseCanvas.enabled = true;
            inHouse = true;
            //ShowCollection();
        }
    }

    //private void ShowCollection()
   // {
        //Debug.Log("Collected Items:");
        //foreach (string item in collectedItems)
        //{
            //Debug.Log(item);
            //GameObject collectedObjects<item>.enabled = true;
        //}
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inHouseZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inHouseZone = false;
            inHouse = false;
        }
    }
}
