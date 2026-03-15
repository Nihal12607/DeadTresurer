using UnityEngine;

public class spike_collide : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            if (anim != null)
                anim.SetBool("isHit", true);

            Collider2D col = collision.gameObject.GetComponent<Collider2D>();
            if (col != null)
                col.enabled = false;
        }
    }
}
