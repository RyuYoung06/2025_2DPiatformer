using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody2D rd;
    private bool isMovingRight = true;

    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (isMovingRight)

            rd.velocity = new Vector2(moveSpeed, rd.velocity.y);
        else
            rd.velocity = new Vector2(-moveSpeed, rd.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            isMovingRight = !isMovingRight;
        }
    }

}