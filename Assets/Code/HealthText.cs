using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HealthText : MonoBehaviour
{
    public TextMeshProUGUI healthText;   // назначьте в инспекторе ваш UI Text
    public Player player;    // ссылка на скрипт Player

    void Update()
    {
        if (player != null && healthText != null)
        {
            healthText.text = "Health: " + player.health.ToString();
        }
    }
}