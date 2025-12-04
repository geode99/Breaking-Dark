using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseTriggerZone : MonoBehaviour
{
    public bool inHouseZone = false;
    public bool M = false;
    public bool D = false;
    public HouseControls HouseControlsReference;
    public bool inHouse = false;
    public Canvas houseCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        M = HouseControlsReference.M;
        D = HouseControlsReference.D;
        if (M && D && inHouseZone)
        {
            Debug.Log("In House Zone and M pressed");
            houseCanvas.enabled = true;
            inHouse = true;
        }
    }

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
