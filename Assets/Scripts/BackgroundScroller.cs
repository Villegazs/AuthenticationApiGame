using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    public bool isGround = true;
    private float width;
    [SerializeField]private float scrollSpeed = -2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        width = collider.size.x;
        if(!isGround)
            collider.enabled = false;
        rb.linearVelocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < - width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = new Vector3(transform.position.x + resetPosition.x,transform.position.y ,transform.position.z);
        }
    }
}
