using UnityEngine;
using TMPro;

public class StatsManagerment : MonoBehaviour
{
    public static StatsManagerment Instance;
    public TMP_Text healthText;


    [Header("Combat")]
    public int damage;
    public int damageHaevy;
    public float weaponRange;
    public float CR;
    public float CD;
    public int DEF;
    public int Flat_Pen;
    public float Perc;

    [Header("Movement Stats")]

    public int speed;

    [Header("Health Stats")]

    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance =this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;
        healthText.text = "HP: "+currentHealth+ "/" + maxHealth; 
    }

    public void UpdateMaxATK(int amount)
    {
        damage += amount;
        damageHaevy += amount *2;
        


    }

    public void UpdateDef(int amount)
    {
        DEF += amount;
    }



}
