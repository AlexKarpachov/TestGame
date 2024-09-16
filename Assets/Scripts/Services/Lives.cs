using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Gamemanager gamemanager;

    int livesLeft = 3;
    int score = 0;

    private void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + livesLeft.ToString();
    }

    public void LivesUpdate()
    {
        livesLeft--;
        if (livesLeft <= 0)
        {
            gamemanager.GameOver();
        }
        livesText.text = "Lives: " + livesLeft.ToString();
    }
    public void ScoreUpdate()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
