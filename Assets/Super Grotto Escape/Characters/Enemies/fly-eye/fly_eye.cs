using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 2f;

    public GameObject fireballPrefab;
    public float shootInterval = 5f;

    private Vector3 startPos;
    private Transform player;

    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("Shoot", 2f, shootInterval);
    }

    void Update()
    {
        float movement = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = new Vector3(startPos.x, startPos.y + movement, startPos.z);
    }

    void Shoot()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;

        // Enemy is facing LEFT
        float dot = Vector2.Dot(-transform.right, direction);

        if (dot <= 0)
        {
            return; // player is behind enemy
        }

        Vector3 spawnPos = transform.position + (-transform.right * 0.8f);

        GameObject fireball = Instantiate(fireballPrefab, spawnPos, Quaternion.identity);

        fireball.GetComponent<Fireball>().SetDirection(direction);
    }
}