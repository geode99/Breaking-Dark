using UnityEngine;
using UnityEngine.UI;

public class PlayerHealths : MonoBehaviour
{
    public float ShadyHealth = 100f;
    public float FireflyHealth = 100f;

    public Image LightBar;
    public Image HealthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(FireflyHealth < 0){
            ShadyHealth += FireflyHealth;
            FireflyHealth = 0;
        }  
        if(ShadyHealth < 0){
            FireflyHealth += ShadyHealth;
            ShadyHealth = 0;
        }
        if(ShadyHealth > 100f){
            ShadyHealth = 100f;
        }
        if(FireflyHealth > 100f){
            FireflyHealth = 100f;
        }
        LightBar.fillAmount = FireflyHealth/100;
        HealthBar.fillAmount = ShadyHealth/100;
    }
}
