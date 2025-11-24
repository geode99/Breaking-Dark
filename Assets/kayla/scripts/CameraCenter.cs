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
    public float CameraSpeed;
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
        Vector3 newPos = new Vector3(centerx, centery, camera.transform.position.z);
        camera.transform.position = Vector3.Lerp(camera.transform.position, newPos, Time.deltaTime * CameraSpeed);
        camera.orthographicSize =Distance(wizard.transform.position, firefly.transform.position) + zoom;

        if (camera.orthographicSize > maxZoom)
        {
            camera.orthographicSize = maxZoom;
            if ((wizard.transform.position.x + firefly.transform.position.x) > xmax || (wizard.transform.position.y + firefly.transform.position.y) > ymax)
            { 
                if (isWizard && wizard.transform.position.y != camera.transform.position.y)
                {
                    Vector3 newPos2 =new Vector3(wizard.transform.position.x, wizard.transform.position.y + 1, camera.transform.position.z);
                    camera.transform.position = Vector3.Lerp(camera.transform.position, newPos2, Time.deltaTime * CameraSpeed);
                }
                if (isWizard == false && firefly.transform.position.y != camera.transform.position.y)
                {
                    Vector3 newPos2 = new Vector3(firefly.transform.position.x, firefly.transform.position.y + 1, camera.transform.position.z);
                    camera.transform.position = Vector3.Lerp(camera.transform.position, newPos2, Time.deltaTime * CameraSpeed);
                }
            }
        }
        if (camera.orthographicSize < minZoom)
        {
            camera.orthographicSize = minZoom;
        }
    }

    private float Distance(Vector2 a, Vector2 b)
    {
        float dx = a.x - b.x;
        float dy = a.y - b.y;
        return Mathf.Sqrt(dx * dx + dy * dy);
    }
}
