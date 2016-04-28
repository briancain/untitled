﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

  private Rigidbody2D rb;
  private BoxCollider2D boxCollider;
  private Transform playerTransform;
  private Vector2 playerPosition;

  // Use this for initialization
  void Start () {
  }
  // Update is called once per frame
  void Update () {
    rb = gameObject.GetComponent<Rigidbody2D>();
  }
}
