using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    FloatVariable score;

    TextMeshProUGUI scoreText;
    void Awake()
    {
        if (SceneManager.GetActiveScene().name != "Game Over")
        {
            score.Value = 0;
        }
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreText.text = score.Value.ToString();
    }
}
