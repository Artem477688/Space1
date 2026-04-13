using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeadScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;   // назначьте в инспекторе ваш UI Text
    public Player player;    // ссылка на скрипт Player

    void Start()
    {
        if (scoreText != null)
        {
            scoreText.text = player.score.ToString();
        }
    }
}