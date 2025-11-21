using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    public GameObject wizard;
    public GameObject firefly;
    public float centerx;
    public float centery;
    public Camera camera;
    public float zoom = 5.0f;
    public float maxZoom = 10.0f;
    public float minZoom = 5.0f;
    public float xmax = 100.0f;
    public float ymax = 100.0f;
    private bool isWizard;
    public PlayerMovement playerMovementReference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera.orthographicSize = minZoom;
    }

    // Update is called once per frame
    void Update()
    {
        isWizard = playerMovementReference.isWizard;
        centerx = (wizard.transform.position.x + firefly.transform.position.x) / 2;
        centery = (wizard.transform.position.y + firefly.transform.position.y) / 2;
        camera.transform.position = new Vector3(centerx, centery, camera.transform.position.z);
        camera.orthographicSize = Mathf.Abs(wizard.transform.position.x - firefly.transform.position.x) + zoom;

        if (camera.orthographicSize > maxZoom)
        {
            camera.orthographicSize = maxZoom;
            if ((wizard.transform.position.x + firefly.transform.position.x) > xmax || (wizard.transform.position.y + firefly.transform.position.y) > ymax)
            { 
                if (isWizard && wizard.transform.position.y != camera.transform.position.y)
                {
                    camera.transform.position = new Vector3(wizard.transform.position.x, wizard.transform.position.y + 1, camera.transform.position.z);
                }
                if (isWizard == false && firefly.transform.position.y != camera.transform.position.y)
                {
                    camera.transform.position = new Vector3(firefly.transform.position.x, firefly.transform.position.y + 1, camera.transform.position.z);
                }
            }
        }
        if (camera.orthographicSize < minZoom)
        {
            camera.orthographicSize = minZoom;
        }
    }
}
