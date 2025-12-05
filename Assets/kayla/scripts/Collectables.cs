using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class Collectables : MonoBehaviour
{
    public TextMeshProUGUI collectableText;
    private Color startColor;
    //private Color endColor;
    private Color resetColor;
    public float fadeDuration = 2f;
    public List<string> collectedItems = new List<string>();
    public string itemName;
    //float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collectableText.enabled = false;
        startColor = collectableText.color;
        //endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        resetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);
        collectableText.color = resetColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeOut()
    {
        collectableText.CrossFadeAlpha(1f, 0f, false);
        collectableText.CrossFadeAlpha(0f, fadeDuration, false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collectableText.enabled = true;
            Destroy(gameObject);
            FadeOut();
            collectableText.color = resetColor;
            collectedItems.Add(itemName);
        }
    }
}
