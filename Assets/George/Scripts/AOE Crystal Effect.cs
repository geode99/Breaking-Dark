using Unity.VisualScripting;
using UnityEngine;

public class AOECrystalEffect : MonoBehaviour
{
    public PlayerHealths hp;
    public PlayerMovement IsWiz;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other){
        if(other.tag == "BadCrystal"){
            if(IsWiz.isWizard)
            {
                hp.FireflyHealth--;
            }
            else{ 
                hp.ShadyHealth++;
            }
        }
        else if(other.tag == "GoodCrystal"){
            if(!IsWiz.isWizard)
            {
                hp.ShadyHealth--;
            }else{
                hp.FireflyHealth++;
            }
        }
    }
}
