using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public GameObject wizard;
    public GameObject firefly;

    public PlayerMovement IsWiz;

    void Update(){
        if(IsWiz.isWizard){
            transform.position = wizard.transform.position;
        }else{
            transform.position = firefly.transform.position;
        }
    }
}
