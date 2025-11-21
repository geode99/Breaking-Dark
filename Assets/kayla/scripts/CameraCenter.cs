using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    public GameObject wizard;
    public GameObject firefly;
    public float centerx;
    public float centery;
    private Transform camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        centerx = (wizard.transform.position.x + firefly.transform.position.x) / 2;
        centery = (wizard.transform.position.y + firefly.transform.position.y) / 2;
        camera.position = new Vector2(centerx, centery);
    }
}
