using Unity.VisualScripting;
using UnityEngine;

public class AOECrystalEffect : MonoBehaviour
{
    public float drain = 4f;
    public float enemyDamage = 3f;

    public PlayerHealths hp;
    public PlayerMovement IsWiz;

    private Collider2D other;

    public SpriteRenderer shadySR;
    public SpriteRenderer walterSR;
    public bool colorflash = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        walterSR.color = Color.white;
        shadySR.color = Color.white;
        if (other)
        {
            if (other.CompareTag("Enemy")&& IsWiz.isWizard)
            {
                hp.ShadyHealth -= Time.deltaTime * drain * enemyDamage;
            }
            else if (other.CompareTag("BadCrystal"))
            {
                if (!IsWiz.isWizard)
                {
                    hp.FireflyHealth -= Time.deltaTime * drain;
                    if (colorflash)
                    {
                        walterSR.color = new Color(0.7843138f, 0.1921569f, 0.8901961f);
                        colorflash = false;
                    }
                    else
                    {
                        walterSR.color = Color.white;
                        colorflash = true;
                    }
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
                    if (colorflash){
                        shadySR.color = new Color(0.9960785f, 0.8039216f, 0.482353f);
                        colorflash = false;
                    }else{
                        shadySR.color = Color.white;
                        colorflash = true;
                    }
                }else{
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
