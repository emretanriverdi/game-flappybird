using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float force = 250.0f;
    private Rigidbody2D rb;
    public bool isDead;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead) {
            transform.Rotate(0, 0, -1.0f);
            if (Input.GetMouseButtonDown(0)) {

                transform.rotation = Quaternion.Euler(0, 0, 30);

                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * force);

                anim.SetTrigger("FLap");
            }
        }
	}

    public void OnCollisionEnter2D(Collision2D collision) {
        isDead = true;
        anim.SetTrigger("Die");
        GameManager.Instance.BirdDied();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameManager.Instance.IncreaseScore();
    }

}
