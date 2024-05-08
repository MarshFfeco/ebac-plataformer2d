using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Header("Movement")]
    public float speed = 5;
    public float speedrun = 7;
    public float forceJump = 13.0f;

    [Header("Animation")]
    public float jumpScaleY = 2.0f;
    public float jumpScaleX = .5f;
    public float animationDuration = .3f;

    private float _currentSpeed;
    private bool _IsJump = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _IsJump = true;
            _rb.transform.localScale = Vector2.one;

            DOTween.Kill(_rb.transform);
            HandleScaleFloor();
        }
    }


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
        if (Input.GetKey(KeyCode.LeftShift))
            _currentSpeed = speedrun;
        else
            _currentSpeed = speed;

        if (Input.GetKey(KeyCode.D))
            _rb.velocity = new Vector2(_currentSpeed, _rb.velocity.y);
        else if (Input.GetKey(KeyCode.A))
            _rb.velocity = new Vector2(-_currentSpeed, _rb.velocity.y);
        else
            _rb.velocity = new Vector2(0, _rb.velocity.y);
    }

    private void HandleJump()
    {
        if (_IsJump && Input.GetKeyDown(KeyCode.W))
        {
            _IsJump = false;
            _rb.velocity = Vector2.up * forceJump;
            _rb.transform.localScale = Vector2.one;

            DOTween.Kill(_rb.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        _rb.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo);
        _rb.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo);
    }

    private void HandleScaleFloor()
    {
        _rb.transform.DOScaleX(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo);
    }
}
