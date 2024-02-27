using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Header("Movement")]
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed = 5;
    public float forceJump = 5.0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.D))
            // _rb.MovePosition(_rb.position + velocity * Time.deltaTime);
            _rb.velocity = new Vector2(speed, _rb.velocity.y);
        else if (Input.GetKey(KeyCode.A))
            // _rb.MovePosition(_rb.position - velocity * Time.deltaTime);
            _rb.velocity = new Vector2(-speed, _rb.velocity.y);

        if (_rb.velocity.x > 0)
            _rb.velocity += friction;
        else if (_rb.velocity.x < 0)
            _rb.velocity -= friction;
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _rb.velocity = Vector2.up * forceJump;
    }
}
