using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public float speed = 2f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Player hit
        if (collision.gameObject.CompareTag("Player"))
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            if (anim != null)
                anim.SetBool("isHit", true);

            Collider2D col = collision.gameObject.GetComponent<Collider2D>();
            if (col != null)
                col.enabled = false;
        }
        else
        {
            // Check if collision is from the side
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (Mathf.Abs(contact.normal.x) > 0.5f)
                {
                    Flip();
                    break;
                }
            }
        }
    }

    void Flip()
    {
        speed *= -1;
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}