using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

  private Rigidbody2D rb;
  private BoxCollider2D boxCollider;
  private Transform playerTransform;
  private Vector2 playerPosition;

  // Use this for initialization
  void Start () {
    rb = gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update () {
    Move();
  }

  void Move() {
    if (rb.position.y <= 5f) {
      rb.velocity = new Vector2(0f, 8f);
    } else {
      Destroy(gameObject);
    }
  }
}
