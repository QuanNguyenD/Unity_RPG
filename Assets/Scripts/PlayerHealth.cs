using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int currenthealth;

    public int maxHealth;

    public TMP_Text healthText;
    public Animator healthAnimator;

    public void Start()
    {
        healthText.text = "HP: " + currenthealth + "/" + maxHealth;
    }
    public void ChangeHealth(int amount)
    {
        currenthealth += amount;

        healthAnimator.Play("TextUpdate");
        healthText.text = "HP: " + currenthealth + "/" + maxHealth;

        if (currenthealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
