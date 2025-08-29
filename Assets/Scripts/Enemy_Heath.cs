using UnityEngine;
using UnityEngine.Rendering;

public class Enemy_Heath : MonoBehaviour
{
    public int expReward = 5;
    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated onMonsterdefeated;


    public int currentHealth;
    public int maxHealth;

    public int DEF;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            onMonsterdefeated(expReward);
            Destroy(gameObject);
        }
    }
       public void TakeDamege(int rawDamage, int flatPen,float perPen )
    {
        int def = DEF;

        float effectiveDEF = Mathf.Max(0, (def - flatPen) * (1f - perPen));

        int finalDamege = Mathf.RoundToInt(rawDamage * (100f / (100f + effectiveDEF)));

        ChangeHealth( -finalDamege);
    }
}
