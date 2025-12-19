using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	int score = 0;
	GameObject scoreText;
	GameObject gameOverText;
	[SerializeField]
	private TextMeshProUGUI point;

	public void AddScore(){
		this.score += 5;
	}
	[SerializeField]
	private TextMeshProUGUI gameover;
	public void GameOver(){
		this.gameOverText.GetComponent<Text>().text = "GameOver";
	}

	void Start () {
		this.scoreText = GameObject.Find ("Score");
		this.gameOverText = GameObject.Find ("GameOver");
	}

	void Update () {
		point.text = "Score:" + score.ToString("D5");
	}
}
