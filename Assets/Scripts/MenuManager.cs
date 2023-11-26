using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    private string mainSceneName = "Game";

    private void Start()
    {
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", 0).ToString();
     UpdateBestScoreUI();
    }

    public void ResetBestScore()
    {
        // Establece el "Best Score" a 0 y guarda el cambio
        PlayerPrefs.SetInt("BestScore", 0);
        PlayerPrefs.Save(); // Guarda los cambios en PlayerPrefs

        // Actualiza el texto del mejor puntaje en la UI
        UpdateBestScoreUI();
    }

    private void UpdateBestScoreUI() {
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", 0).ToString();
    }


    public void StartGame()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
