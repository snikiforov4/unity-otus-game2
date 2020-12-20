using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    private static readonly int SpeedX = Animator.StringToHash("speed");
    private static readonly int SpeedY = Animator.StringToHash("vertical speed");
    private static readonly int InAir = Animator.StringToHash("in air");

    private Rigidbody2D _rigidBody2D;
    private TriggerDetector _triggerDetector;
    private Animator _animator;
    private float _visualDirection;

    public Transform visual;
    public TextMeshProUGUI gameOverText;
    public float moveForce;
    public float jumpForceX;
    public float jumpForceY;

    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _triggerDetector = GetComponentInChildren<TriggerDetector>();
        _animator = GetComponentInChildren<Animator>();
        _visualDirection = 1.0f;
    }

    public void MoveLeft()
    {
        if (_triggerDetector.OnGround())
            _rigidBody2D.AddForce(new Vector2(-moveForce, 0.0f), ForceMode2D.Impulse);
    }

    public void MoveRight()
    {
        if (_triggerDetector.OnGround())
            _rigidBody2D.AddForce(new Vector2(moveForce, 0.0f), ForceMode2D.Impulse);
    }

    public void Jump()
    {
        if (_triggerDetector.OnGround())
        {
            var directionalJumpForceX = _visualDirection > 0 ? jumpForceX : -jumpForceX;
            _rigidBody2D.AddForce(new Vector2(directionalJumpForceX, jumpForceY), ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        if (_triggerDetector.Drawn())
        {
            OnGameOver();
            return;
        }
        float velocityX = _rigidBody2D.velocity.x;
        float velocityY = _rigidBody2D.velocity.y;

        if (velocityX < -0.01f)
            _visualDirection = -1.0f;
        else if (velocityX > 0.01f)
            _visualDirection = 1.0f;

        Vector3 scale = visual.localScale;
        scale.x = _visualDirection;
        visual.localScale = scale;

        _animator.SetFloat(SpeedX, Mathf.Abs(velocityX));
        _animator.SetFloat(SpeedY, velocityY);
        _animator.SetBool(InAir, _triggerDetector.InAir());
    }
    
    private void OnGameOver()
    {
        gameOverText.text = "Game Over";
    }
    
}