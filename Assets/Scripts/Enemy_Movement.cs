using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Transform player;
    private Vector2 startPosition;

    private int facingDirection = 1;
    public float playerDetectRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    private EnemyState enemyState;
    private float attackCooldownTimer;

    public float attackRange = 2f;
    public float attackCooldown = 2f;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);

        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();
        if(attackCooldownTimer > 0)
        {
            attackCooldownTimer -=Time.deltaTime;
        }

        if (enemyState == EnemyState.Chasing) {
            
            Chase();
        }

        else if (enemyState ==EnemyState.Attacking)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            Vector2 direction = (startPosition - (Vector2)transform.position).normalized;

            if (Vector2.Distance(transform.position, startPosition) > 0.1f)
            {
                if (startPosition.x > transform.position.x && facingDirection == -1 ||
                startPosition.x < transform.position.x && facingDirection == 1)
                {
                    Flip();
                }
                rb.linearVelocity = direction * speed;
                anim.SetBool("Is_Chasing", true);
            }
            else
            {
                // Stop moving when close enough to the start position
                rb.linearVelocity = Vector2.zero;
                anim.SetBool("Is_Chasing", false);
            }
        }
        
    }

    void Chase()
    {
        

        if (player.position.x > transform.position.x && facingDirection == -1 ||
                player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }
        Vector2 diraction = (player.position - transform.position).normalized;
        rb.linearVelocity = diraction * speed;
    }
    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);

        if (hits.Length > 0)
        {
            player = hits[0].transform;

            //if the player is in attackRange AND cooldown is ready 
            if (Vector2.Distance(transform.position, player.position) <= attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                ChangeState(EnemyState.Attacking);
            }
            else if (Vector2.Distance(transform.position, player.position) > attackRange && enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);

        }


            
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.linearVelocity = Vector2.zero;
            
            ChangeState(EnemyState.Idle);
        }
    }
    void Flip()
    {
        facingDirection *= -1;

        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }

    void ChangeState(EnemyState newState)
    {

        //Exit  the curren animation 
        if(enemyState == EnemyState.Idle)
        {
            anim.SetBool("Is_Idle", false);
        }
        else if(enemyState == EnemyState.Chasing)
        {
            anim.SetBool("Is_Chasing", false);
        }
        else if (enemyState == EnemyState.Attacking)
        {
            anim.SetBool("Is_Attacking", false);
        }

            //Update our current state
            enemyState = newState;

        //Update the new animaation 
        if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("Is_Idle", true);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("Is_Chasing", true);
        }
        else if (enemyState == EnemyState.Attacking)
        {
            anim.SetBool("Is_Attacking", true);
        }

        


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
    }

    public void Attack()
    {
        Debug.Log("Attack player");
    }

    



}
public enum EnemyState
{

    Idle,
    Chasing,
    Attacking,

}
