using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = -10.0f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.gameOver) {
            rb.velocity = Vector2.zero;
        }
	}
}
