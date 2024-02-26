using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Header("Movement")]
    public Vector2 velocity;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
            // _rb.MovePosition(_rb.position + velocity * Time.deltaTime);
            _rb.velocity = velocity;
        else if (Input.GetKey(KeyCode.A))
            // _rb.MovePosition(_rb.position - velocity * Time.deltaTime);
            _rb.velocity = -velocity;
    }
}
