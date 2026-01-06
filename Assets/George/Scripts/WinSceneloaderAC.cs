using UnityEngine;
using UnityEngine.SceneManagement;


public class WinSceneloaderAC : MonoBehaviour
{
    //public string scene;
    public PlayerHealths Health;
    public Canvas deathCanvas;
    public Canvas win;
    public PlayerMovement PlayerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathCanvas.enabled = false;
        win.enabled = false;
    }

    //Audio stuff
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.ShadyHealth <= 0)
        {
            deathCanvas.enabled = true;
            //UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
            audioManager.PlaySFX(audioManager.restart);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal" && PlayerMovement.isWizard)
        {
            win.enabled = true;
            //UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
            audioManager.PlaySFX(audioManager.portal);
        }
    }
}

