using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{

    int damege = 1;

    public Transform attackPoint;

    public float weaponRange;

    public float knockbackForce;
    public float stunTime;
    public LayerMask playerLayer;


    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        if (hits.Length > 0 && hits[0].gameObject.activeInHierarchy) {
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damege);
            hits[0].GetComponent<PlayerMovement>().KnockBack(transform, knockbackForce, stunTime);
        }
    }
}
