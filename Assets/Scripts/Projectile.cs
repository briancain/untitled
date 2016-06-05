using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

  private Rigidbody2D rb;
  private BoxCollider2D boxCollider;
  private float speed;

  private float screenRatio;
  private float widthOrthographic;

  private Transform playerTransform;

  // Use this for initialization
  void Start () {
    rb = gameObject.GetComponent<Rigidbody2D>();
    speed = 8f;

    // Figure out screen bounds
    screenRatio = (float)Screen.width / (float)Screen.height;
    widthOrthographic = Camera.main.orthographicSize * screenRatio;
  }

  // Update is called once per frame
  void Update () {
    Vector3 position = transform.position;
    Vector3 velocity = new Vector3(0f, speed * Time.deltaTime, 0f);
    position += transform.rotation * velocity;
    if (InBounds(position)) {
      transform.position = position;
    }
  }

  bool InBounds(Vector3 position) {
    if ((position.y > Camera.main.orthographicSize)
        || (position.y < -Camera.main.orthographicSize)
        || (position.x > widthOrthographic)
        || (position.x < -widthOrthographic)) {
      Destroy(gameObject);
      return false;
    } else {
      return true;
    }
  }

  /*
   *  Called by other game objects when
   *  they collide with a projectile
   */
  public void DestroyObject() {
    Debug.Log("Destroy Projectile");
    Destroy(gameObject);
  }
}
