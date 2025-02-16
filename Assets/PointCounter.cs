using UnityEngine;
using TMPro;
public class PointCounter : MonoBehaviour
{
    private int currentScore = 0;
    public TextMeshProUGUI scoreUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreUI.text = "Score: " + currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IncrementScore()
    {
        currentScore++;
        scoreUI.text = "Score: " + currentScore.ToString();
    }
}
