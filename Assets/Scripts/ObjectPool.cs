using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public GameObject obj;

    public float timeInterval = 2.0f;

    public float xPosition = 10.0f;

    public int poolSize = 10;

    public Vector2 iPos = new Vector2(-30.0f, -30.0f);

    private GameObject[] columns;

    public float minY = -1.2f;
    public float maxY = 2.0f;

    private float timePassed = 0.0f;
    private int currentColumn = 0;

    public GameObject bird;

    private float totalTimePassed = 0.0f;
    private float minTime = 5.0f;

	// Use this for initialization
	void Start () {
        columns = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++) {
            columns[i] = Instantiate(obj, iPos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {

        totalTimePassed += Time.deltaTime;
        if (totalTimePassed >= minTime && timeInterval >= 1.0f) {
            totalTimePassed = 0.0f;
            timeInterval -= 0.05f;
        }

        if (!GameManager.Instance.gameOver) {
            timePassed += Time.deltaTime;

            if (timePassed >= timeInterval) {
                timePassed = 0.0f;

                float y = Random.Range(minY, maxY);
                columns[currentColumn++].transform.position = new Vector2(bird.transform.position.x + xPosition, y);

                if (currentColumn >= poolSize)
                    currentColumn = 0;
            }
        }
	}
}