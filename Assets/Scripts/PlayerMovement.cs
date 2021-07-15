using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int maxHealth = 8;
    public int currentHealth;

    public HealthBar healthBar;

    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
    }

    //PLAYER HIT
    public void PlayerHit(int _damage)
    {
        currentHealth -= _damage;
    }

    //COLLISION CHECK
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            SceneManager.LoadScene("DEMO");
        }

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

}
