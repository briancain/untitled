using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

  private float playerSpeed;
  private Rigidbody2D rb;

  void rotateLeft() {
    transform.Rotate(Vector3.forward * -10);
  }

  void rotateRight() {
    transform.Rotate(Vector3.forward * 10);
  }

  void Move() {
    float inputVelocityX = Input.GetAxisRaw("Horizontal") * playerSpeed;
    float inputVelocityY = Input.GetAxisRaw("Vertical") * playerSpeed;

    float velocityX = 0;
    float velocityY = 0;

    if (inputVelocityX > 0) {
      rotateRight();
    } else if (inputVelocityX < 0) {
      rotateLeft();
    }

    if (inputVelocityY > 0) {
      velocityY = inputVelocityY;
    }

    rb.velocity = new Vector2(0, velocityY);
  }

  // Use this for initialization
  void Start () {
    playerSpeed = 5;
    rb = gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update () {
    Move();
  }
}
