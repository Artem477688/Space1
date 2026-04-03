using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;   // назначьте в инспекторе ваш UI Text
    public Player player;    // ссылка на скрипт Player

    void Update()
    {
        if (player != null && scoreText != null)
        {
            scoreText.text = "Score: " + player.score.ToString();
        }
    }
}