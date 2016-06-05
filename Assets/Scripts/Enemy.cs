using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

  private Rigidbody2D rb;

  // Use this for initialization
  void Start () {
    rb = gameObject.GetComponent<Rigidbody2D>();
  }
  // Update is called once per frame
  void Update () {
  }

  void Move() {

  }

  void DestroyEnemy() {
    Debug.Log("Dead");
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
