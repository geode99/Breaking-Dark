using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    public TextMeshProUGUI collectableText;
    private Color startColor;
    private Color endColor;
    private Color resetColor;
    public float fadeDuration = 2f;
    float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collectableText.enabled = false;
        startColor = collectableText.color;
        endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        resetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);
        collectableText.color = resetColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collectableText.enabled = true;
            timer += Time.deltaTime;
            float t = timer / fadeDuration;
            collectableText.color = Color.Lerp(startColor, endColor, t);
            collectableText.enabled = false;
            Destroy(gameObject);
        }
    }
}
