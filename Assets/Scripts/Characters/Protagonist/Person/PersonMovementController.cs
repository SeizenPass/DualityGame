using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovementController : MonoBehaviour
{
    private Protagonist _protagonist;
    private InputReader _inputReader;
    private Rigidbody2D _rigidBody2D;
    public float speed;
    public bool canJump = false;
    public bool canDash = false;
    public float jumpForce = 7;
    public float dashCooldown = 1;
    public float dashForce = 5;
    private float lastDashTime;
    private float _inputDirection;
    private bool _facingRight = true;
    private void Awake() {
        _protagonist = GetComponent<Protagonist>();
        _inputReader = _protagonist.inputReader;
        _rigidBody2D = GetComponent<Rigidbody2D>();
        lastDashTime = Time.time - dashCooldown;
    }

    private void OnEnable() {
        _inputReader.moveEvent.OnEventRaised += OnMove;
        _inputReader.jumpEvent.OnEventRaised += OnJump;
        _inputReader.dashEvent.OnEventRaised += OnDash;
    }

    private void OnDisable() {
        _inputReader.moveEvent.OnEventRaised -= OnMove;
        _inputReader.jumpEvent.OnEventRaised -= OnJump;
        _inputReader.dashEvent.OnEventRaised -= OnDash;
    }

    // Update is called once per frame
    void Update()
    {
		transform.position += new Vector3(_inputDirection, 0, 0) * Time.deltaTime * speed;
        Vector3 scale = gameObject.transform.localScale;
        if (_inputDirection > 0) {
            scale.x = Mathf.Abs(scale.x);
            _facingRight = true;
        } else if (_inputDirection < 0) {
            scale.x = Mathf.Abs(scale.x) * (-1);
            _facingRight = false;
        }
        gameObject.transform.localScale = scale;
    }

    private bool FacingRight() {
        return _facingRight;
    }

    private bool IsGrounded() {
        return Mathf.Abs(_rigidBody2D.velocity.y) < 0.001f;
    }

    private void OnMove(float movement)
	{
		_inputDirection = movement;
	}

    private void OnJump() {
        if (canJump && IsGrounded()) {
            _rigidBody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnDash() {
        if (canDash && lastDashTime + dashCooldown < Time.time) {
            _rigidBody2D.AddForce(new Vector2(_facingRight ? dashForce : -dashForce, 0), ForceMode2D.Impulse);
        }
    }
}
