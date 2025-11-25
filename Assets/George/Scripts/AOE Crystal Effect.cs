using Unity.VisualScripting;
using UnityEngine;

public class AOECrystalEffect : MonoBehaviour
{
    public float drain = 4f;

    public PlayerHealths hp;
    public PlayerMovement IsWiz;

    private Collider2D other;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (other)
        {
            if (other.tag == "BadCrystal")
            {
                if (!IsWiz.isWizard)
                {
                    hp.FireflyHealth -= Time.deltaTime * drain;
                }
                else
                {
                    hp.ShadyHealth += Time.deltaTime * drain;
                }
            }
            else if (other.tag == "GoodCrystal")
            {
                if (IsWiz.isWizard)
                {
                    hp.ShadyHealth -= Time.deltaTime * drain;
                }
                else
                {
                    hp.FireflyHealth += Time.deltaTime * drain;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        other = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        other = null;
    }
}
