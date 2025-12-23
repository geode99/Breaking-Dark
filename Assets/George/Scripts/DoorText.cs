using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class DoorText : MonoBehaviour
{
    public TextMeshProUGUI doorText;
    private Color Color;
    private Color resetColor;
    public float fadeDuration = 2f;
    
    void Start()
    {
        doorText.enabled = false;
        Color = doorText.color;
        resetColor = new Color(Color.r, Color.g, Color.b, 1f);
        doorText.color = resetColor;
    }


    public void FadeOut()
    {
        doorText.CrossFadeAlpha(1f, 0f, false);
        doorText.CrossFadeAlpha(0f, fadeDuration, false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            doorText.enabled = true;
            FadeOut();
            doorText.color = resetColor;
        }
    }
}