using UnityEngine;
using UnityEngine.SceneManagement;


public class Sceneloader : MonoBehaviour
{
    public string scene;
    public PlayerHealths Health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
            audioManager.PlaySFX(audioManager.portal);
        }
    }
}
