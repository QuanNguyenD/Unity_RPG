using UnityEngine;

public class Elevation_Entry : MonoBehaviour
{


    public Collider2D[] mountainCollider;
    public Collider2D[] boundaryCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D mountant in mountainCollider)
            {
                mountant.enabled = false;

            }

            foreach (Collider2D boundary in boundaryCollider)
            {
                boundary.enabled = true;

            }
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15; 
        }
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
