using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

  private Rigidbody2D rb;
  private BoxCollider2D boxCollider;
  private float speed;

  private Transform playerTransform;

  // Use this for initialization
  void Start () {
    rb = gameObject.GetComponent<Rigidbody2D>();
    speed = 8f;
  }

  // Update is called once per frame
  void Update () {
    // TODO: need checks to destroy game object if out of bounds
    Vector3 position = transform.position;
    Vector3 velocity = new Vector3(0f, speed * Time.deltaTime, 0f);
    position += transform.rotation * velocity;
    transform.position = position;
  }
}
