using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    Rigidbody2D _rb2d;
    bool _isJumping = false;
    bool _isGrounded = true;
    Vector2 _horizontalVelocity = new Vector2(0f, 0f);
    float _jumpForce;

    public void Move(Vector2 velocity) {
        _horizontalVelocity = velocity;
    }

    public void Jump(float jumpForce) {
        if (_isGrounded) {
            _isJumping = true;
            _jumpForce = jumpForce;
        }
    }

    void Start() {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        _rb2d.MovePosition(_rb2d.position + _horizontalVelocity * Time.fixedDeltaTime);

        if (_isJumping) {
            _rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            Debug.Log("Jump => FixedUpdate");
            Debug.Log(_rb2d.velocity);
            _isJumping = false;
        }
        Debug.Log(_rb2d.velocity);

    }


    void OnCollisionEnter2D(Collision2D collision) {
        LayerMask ground = LayerMask.NameToLayer("Ground");

        if (collision.gameObject.layer == ground) {
            Debug.Log("Collision with ground");
            _isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        LayerMask ground = LayerMask.NameToLayer("Ground");

        if (collision.gameObject.layer == ground) {
            Debug.Log("Collision exit with ground");
            _isGrounded = false;
        }
    }
}
