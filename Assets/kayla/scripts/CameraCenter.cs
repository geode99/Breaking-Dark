using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    public GameObject wizard;
    public GameObject firefly;
    public Vector2 center;
    private GameObject camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        center = (wizard.transform.position + firefly.transform.position) / 2;
        camera.transform.position = new Vector2(center.x, center.y);
    }
}
