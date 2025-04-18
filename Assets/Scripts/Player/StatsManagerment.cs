using UnityEngine;

public class StatsManagerment : MonoBehaviour
{
    public static StatsManagerment Instance;


    [Header("Combat")]
    public int damage;
    public int damageHaevy;
    public float weaponRange;

    [Header("Movement Stats")]

    public int speed;

    [Header("Health Stats")]

    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance =this; ;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
