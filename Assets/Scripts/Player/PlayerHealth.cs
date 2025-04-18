using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    //public int currenthealth;

    //public int maxHealth;

    public TMP_Text healthText;
    public Animator healthAnimator;

    public void Start()
    {
        healthText.text = "HP: " + StatsManagerment.Instance.currentHealth + "/" + StatsManagerment.Instance.maxHealth;
    }
    public void ChangeHealth(int amount)
    {
        StatsManagerment.Instance.currentHealth += amount;

        healthAnimator.Play("TextUpdate");
        healthText.text = "HP: " + StatsManagerment.Instance.currentHealth + "/" + StatsManagerment.Instance.maxHealth;

        if (StatsManagerment.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
