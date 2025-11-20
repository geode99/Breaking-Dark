using UnityEngine;

public class PlayerHealths : MonoBehaviour
{
    public float ShadyHealth = 100f;
    public float FireflyHealth = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(FireflyHealth < 0){
            ShadyHealth += FireflyHealth;
        }  
        if(ShadyHealth < 0){
            FireflyHealth += ShadyHealth;
        }
    }
}
