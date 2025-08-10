using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int totalScore;
    public static ScoreUpdate Instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
        scoreText = GameObject.Find("ScoreTMP").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        totalScore += score;
        scoreText.text = "Score: " + totalScore;
    }
}
