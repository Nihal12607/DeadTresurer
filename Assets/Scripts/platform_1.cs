using UnityEngine;

public class MovingPlatform_1 : MonoBehaviour
{
    public float leftX = 6f;
    public float rightX = 33f;
    public float speed = 5f;

    private bool movingLeft = true;

    void Update()
    {
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