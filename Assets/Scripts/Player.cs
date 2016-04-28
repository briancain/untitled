using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

  private float playerSpeed;
  private Rigidbody2D rb;

  void Move() {
    float inputVelocityX = Input.GetAxisRaw("Horizontal") * playerSpeed;
    float inputVelocityY = Input.GetAxisRaw("Vertical") * playerSpeed;

    rb.velocity = new Vector2(inputVelocityX, inputVelocityY);
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
