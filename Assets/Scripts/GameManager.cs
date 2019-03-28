using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text score;
    public static GameManager Instance;
    public GameObject goText;
    public bool gameOver = false;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		if (gameOver && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameOver = false;
        }
	}

    public void IncreaseScore() {
        string scoreText = score.text.Split(' ')[0].ToString();
        int sc = int.Parse(score.text.Split(' ')[1].ToString());

        score.text = scoreText + " " + (sc + 1).ToString();
    }

    public void BirdDied() {
        goText.SetActive(true);

        gameOver = true;
    }

}
