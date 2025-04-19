using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //public float speed = 5;
    public int facingDirection = 1;


    public Rigidbody2D rb;
    public Animator animator;

    private bool isKnockedBack;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public PlayerCombat player_Combat;

    private void Update()
    {
        if (Input.GetButtonDown("Slash")|| Input.GetMouseButtonDown(0))
        {
            player_Combat.Attack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            player_Combat.HeavyAttack();
        }

    }


    // Update is called x50 frame
    void FixedUpdate()
    {
        if (isKnockedBack == false) {

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 ||
                horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            animator.SetFloat("horizontal", Mathf.Abs(horizontal));
            animator.SetFloat("vertical", Mathf.Abs(vertical));

            rb.linearVelocity = new Vector2(horizontal, vertical) * StatsManagerment.Instance.speed;
        }
        
    }

    void Flip()
    {
        facingDirection *= -1;

        transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y  , transform.localScale.z ); 

    }

    public void KnockBack(Transform enemy, float force, float stunTime)
    {
        if (!gameObject.activeInHierarchy) return;
        isKnockedBack = true;

        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockBackCounter(stunTime));
    }

    IEnumerator KnockBackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;   
        isKnockedBack = false;
    }
}
 