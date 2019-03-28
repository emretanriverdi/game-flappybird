using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D col;
    private float length;

	// Use this for initialization
	void Start () {
        col = GetComponent<BoxCollider2D>();
        length = col.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -length) {
            Repeat();
        }
	}

    void Repeat() {
        transform.position += new Vector3(length * 2 - 1, 0, 0);
    }
}
