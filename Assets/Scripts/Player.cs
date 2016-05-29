using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

  private float playerSpeed;
  private Rigidbody2D rb;

  public Transform projectile;

  void Move() {
    float inputVelocityX = Input.GetAxisRaw("Horizontal") * playerSpeed;
    float inputVelocityY = Input.GetAxisRaw("Vertical") * playerSpeed;

    if (inputVelocityX != 0f) {
      // rotate player
      transform.Rotate(Vector3.forward * inputVelocityX);
    }

    rb.velocity = new Vector2(0f, inputVelocityY);
  }

  // Use this for initialization
  void Start () {
    playerSpeed = 5;
    rb = gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update () {
    if (Input.GetButtonDown("Fire1")) {
      Attack();
    }

    Move();
  }

  void Attack() {
    //Debug.Log("Pew pew");
    Vector3 projPosition = transform.position;
    projPosition.y += 0.7f;
    Instantiate(projectile, projPosition , Quaternion.identity);
  }
}
