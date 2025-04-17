using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackpoint;
    public float weaponRange = 1;
    public LayerMask enemyLayer;
    public int damage = 1;
    public int damageHeavy = 5;

    public float cooldown = 1;
    public float cooldown_heavy = 3;
    private float timer;
    private float timer_heavy;


    private void Update()
    {
        if (timer > 0)
        {
            timer -=Time.deltaTime;
        }
        if (timer_heavy > 0)
        {
            timer_heavy -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        if(timer <= 0)
        {
            anim.SetBool("isAttacking", true);
            


            timer = cooldown;
        }
        
    }

    public void DealDamegeAttack()
    {
        Collider2D[] enemis = Physics2D.OverlapCircleAll(attackpoint.position, weaponRange, enemyLayer);

        if (enemis.Length > 0)
        {
            enemis[0].GetComponent<Enemy_Heath>().ChangeHealth(-damage);
        }
    }
    public void DealDamegeHeavyAttack()
    {
        Collider2D[] enemis = Physics2D.OverlapCircleAll(attackpoint.position, weaponRange, enemyLayer);

        if (enemis.Length > 0)
        {
            enemis[0].GetComponent<Enemy_Heath>().ChangeHealth(-damageHeavy);
        }
        
    }

    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false );
    }

    public void HeavyAttack()
    {
        if (timer_heavy <= 0)
        {
            anim.SetBool("isHeavyAttacking", true);
            timer_heavy = cooldown_heavy;

        }
    }
    public void FinishHeavyAttacking()
    {
        anim.SetBool("isHeavyAttacking", false);
    }
}
