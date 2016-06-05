using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

  private Rigidbody2D rb;
  private BoxCollider2D boxCollider;

  private float screenRatio;
  private float widthOrthographic;

  private float speed;

  private Vector3 target;

  // Use this for initialization
  void Start () {
    rb = gameObject.GetComponent<Rigidbody2D>();
    speed = 3f;

    // Figure out screen bounds
    screenRatio = (float)Screen.width / (float)Screen.height;
    widthOrthographic = Camera.main.orthographicSize * screenRatio;

    setNewTarget();
  }

  // Update is called once per frame
  void Update () {
    Move();
  }

  void setNewTarget() {
    float randX = Random.Range(-widthOrthographic, widthOrthographic);
    float randY = Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize);
    target = new Vector3(randX, randY, 0f);
  }

  void Move() {
    if (transform.position == target) {
      setNewTarget();
    }

    float step = speed * Time.deltaTime;
    transform.position = Vector3.MoveTowards(transform.position, target, step);
  }

  void DestroyEnemy() {
    Destroy(gameObject);
  }

  void OnCollisionEnter2D(Collision2D coll) {
    if (coll.gameObject.tag == "Projectile") {
      // Destroy Projectile
      coll.gameObject.GetComponent<Projectile>().DestroyObject();
      // Destroy Enemy
      DestroyEnemy();
    }
  }
}
