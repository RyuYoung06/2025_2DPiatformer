using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.TerrainTools;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpForce = 1f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rd;
    private Animator pAni;
    private bool isGrounded;
    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        pAni = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rd.velocity = new Vector2(moveInput * moveSpeed, rd.velocity.y);

        if(moveInput < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

        }

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            pAni.SetTrigger("JumpAction");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.CompareTag("Finish"))
        {
            collision.GetComponent<LevelObject>().MoveToNextLevel();
        }

        if (collision.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
