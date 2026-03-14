using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float leftX = 23f;
    public float rightX = 32f;
    public float speed = 2f;

    private bool movingLeft = true;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.N))
        {           
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
        if (movingLeft)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (transform.position.x <= leftX)
                movingLeft = false;
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            if (transform.position.x >= rightX)
                movingLeft = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}