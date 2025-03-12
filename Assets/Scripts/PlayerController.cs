using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsAlive;
    public Rigidbody2D rb;
    public Animator animator;
    public float speed = 2f;
    public float jumpForce = 1f;
    public bool canJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        IsAlive = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Debug.Log("Saltar");
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            animator.SetBool("Ground", false);
        }
        rb.linearVelocityX = speed * Input.GetAxis("Horizontal");

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
        else if(collision.CompareTag("Ground"))
        {
            canJump = true;
            animator.SetBool("Ground", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            canJump = false;
        }
    }
    private void OnDisable()
    {
        IsAlive = false;
    }
}
