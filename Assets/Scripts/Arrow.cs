using UnityEngine;

public class Arrow : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 direction = Vector2.right;

    public float lifeSpawn = 2;
    public float speed;
    public int damage;

    public LayerMask enemyLayer;
    public LayerMask obstacleLayer;

    public SpriteRenderer sr;
    public Sprite buriedSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = direction * speed;
        RotateArrow();
        Destroy(gameObject, lifeSpawn);
    }

    private void RotateArrow()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if((enemyLayer.value & (1 << collision.gameObject.layer)) > 0){
            collision.gameObject.GetComponent<Enemy_Heath>().ChangeHealth(-damage);
        }
        else if ((obstacleLayer.value & (1 << collision.gameObject.layer)) > 0){
            AttachToTarget(collision.gameObject.transform);
        }
    }

    private void AttachToTarget(Transform target)
    {
        sr.sprite = buriedSprite;

        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;

        transform.SetParent(target);
    }


}
