using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Header("Movement")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed = 5;
    public float speedrun;
    public float forceJump = 5.0f;

    private float _currentSpeed;

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
        if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = speedrun;
        else
            _currentSpeed = speed;

        if (Input.GetKey(KeyCode.D))
            _rb.velocity = new Vector2(_currentSpeed, _rb.velocity.y);
        else if (Input.GetKey(KeyCode.A))
            _rb.velocity = new Vector2(-_currentSpeed, _rb.velocity.y);

        if (_rb.velocity.x > 0)
        {
            _rb.velocity -= friction;
            Debug.Log(_rb.velocity.x);
        }

        else if (_rb.velocity.x < 0)
            _rb.velocity += friction;
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _rb.velocity = Vector2.up * forceJump;
    }
}
