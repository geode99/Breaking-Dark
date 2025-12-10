using Unity.VisualScripting;
using UnityEngine;

public class AOECrystalEffect : MonoBehaviour
{
    public float drain = 4f;
    public float enemyDamage = 3f;

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
            if (other.CompareTag("Enemy"))
            {
                if(IsWiz.isWizard)
                {
                    hp.FireflyHealth -= Time.deltaTime * drain * enemyDamage;
                }
                else
                {
                    hp.ShadyHealth -= Time.deltaTime * drain * enemyDamage;
                }
            }
            else if (other.CompareTag("BadCrystal"))
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
            else if (other.CompareTag("GoodCrystal"))
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
        if(collision.CompareTag("BadCrystal") || collision.CompareTag("GoodCrystal") || collision.CompareTag("Enemy"))
        {
            other = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BadCrystal") || collision.CompareTag("GoodCrystal") || collision.CompareTag("Enemy"))
        {
            other = null;
        }
    }
}
