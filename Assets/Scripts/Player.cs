using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

  private Rigidbody2D rb;
  private float screenRatio;
  private float widthOrthographic;

  public Transform projectile;
  public float playerSpeed;
  public float rotationSpeed;

  void Move() {
    float inputX = Input.GetAxis("Horizontal");
    float inputY = Input.GetAxis("Vertical");

    Quaternion rotation = transform.rotation;
    float eulerZ = rotation.eulerAngles.z;
    eulerZ -= inputX * rotationSpeed * Time.deltaTime;
    rotation = Quaternion.Euler(0f, 0f, eulerZ);

    transform.rotation = rotation;

    Vector3 position = transform.position;
    Vector3 velocity = new Vector3(0, inputY * playerSpeed * Time.deltaTime, 0f);
    position += rotation * velocity;

    position = RepositionPlayer(position);
    transform.position = position;
  }

  Vector3 RepositionPlayer(Vector3 position) {
    if (position.y > Camera.main.orthographicSize) {
      position.y = Camera.main.orthographicSize;
    }
    if (position.y < -Camera.main.orthographicSize) {
      position.y = -Camera.main.orthographicSize;
    }

    if (position.x > widthOrthographic) {
      position.x = widthOrthographic;
    }
    if (position.x < -widthOrthographic) {
      position.x = -widthOrthographic;
    }

    return position;
  }

  // Use this for initialization
  void Start () {
    rb = gameObject.GetComponent<Rigidbody2D>();
    playerSpeed = 5f;
    rotationSpeed = 180f;

    // Figure out screen bounds
    screenRatio = (float)Screen.width / (float)Screen.height;
    widthOrthographic = Camera.main.orthographicSize * screenRatio;
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
    Vector3 offset = new Vector3(0f, 0.8f, 0f);
    Vector3 projPosition = transform.rotation * offset;

    Instantiate(projectile, transform.position + projPosition , transform.rotation);
  }
}
