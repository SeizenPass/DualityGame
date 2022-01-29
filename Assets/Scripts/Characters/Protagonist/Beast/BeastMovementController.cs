using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastMovementController : MonoBehaviour
{
    private Protagonist _protagonist;
    private InputReader _inputReader;
    private Rigidbody2D _rigidBody2D;
    public float speed;
    public float jumpForce = 7;
    private float _inputDirection;
    private void Awake() {
        _protagonist = GetComponent<Protagonist>();
        _inputReader = _protagonist.inputReader;
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    
    private void OnEnable() {
        _inputReader.moveEvent.OnEventRaised += OnMove;
        _inputReader.jumpEvent.OnEventRaised += OnJump;
    }

    private void OnDisable() {
        _inputReader.moveEvent.OnEventRaised -= OnMove;
        _inputReader.jumpEvent.OnEventRaised -= OnJump;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(_inputDirection, 0, 0) * Time.deltaTime * speed;
        Vector3 scale = gameObject.transform.localScale;
        if (_inputDirection > 0) {
            scale.x = Mathf.Abs(scale.x);
        } else if (_inputDirection < 0) {
            scale.x = Mathf.Abs(scale.x) * (-1);
        }
        gameObject.transform.localScale = scale;
    }

    private bool IsGrounded() {
        return Mathf.Abs(_rigidBody2D.velocity.y) < 0.001f;
    }

    private void OnMove(float movement)
	{
		_inputDirection = movement;
	}

    private void OnJump() {
        if (IsGrounded()) {
            _rigidBody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
