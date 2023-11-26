using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Una instancia estática para permitir un fácil acceso desde otros scripts.

    public Image[] livesImages; // Referencias a los objetos de imagen que representan las vidas en la UI.
    private int livesRemaining; 
    public int currentScore;
    public int bestScore;
    public TextMeshProUGUI currentScoreText; 
    public TextMeshProUGUI bestScoreText;   
    public GameObject gameOverPanel; 
    public GameObject gameUIPanel;   
    public AudioClip gameOverSound;
    private AudioSource audioSource;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
        gameUIPanel.SetActive(true);
        livesRemaining = livesImages.Length; // Inicializa con el número total de vidas.
        UpdateLivesDisplay(); // Actualiza la UI de vidas al comenzar.
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        currentScore = 0; // Inicia el puntaje actual en 0 para una nueva partida.
        UpdateScoreUI();  // Actualiza la UI con los puntajes al iniciar.
    }

    // Método para llamar cuando el jugador pierde una vida.
    public void LoseLife()
    {
        if (livesRemaining > 0)
        {
            livesRemaining--;
            UpdateLivesDisplay();

            if (livesRemaining == 0)
            {
                // Aquí manejarías el game over.
                audioSource.PlayOneShot(gameOverSound);
                HandleGameOver();
            }
        }
    }

    // Actualiza la representación visual de las vidas.
    private void UpdateLivesDisplay()
    {
        for (int i = 0; i < livesImages.Length; i++)
        {
            livesImages[i].enabled = i < livesRemaining;
        }
    }

    private void UpdateScoreUI() {
    if (currentScoreText != null) {
        currentScoreText.text = "Score: " + currentScore.ToString();
    }
    if (bestScoreText != null) {
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }
}


    public void AddScore(int scoreToAdd) {
        currentScore += scoreToAdd;
        UpdateScoreUI();
        CheckForBestScore();
    }

    private void CheckForBestScore() {
        if (currentScore > bestScore) {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

    private void HandleGameOver()
    {
        CheckForBestScore();
        // Muestra el panel de Game Over
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // Oculta el panel del juego
        if (gameUIPanel != null)
            gameUIPanel.SetActive(false);
    }
public void RestartGame()
{
    Destroy(instance.gameObject);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

public void LoadMenu()
    {
        Destroy(instance.gameObject);
        SceneManager.LoadScene("Menu");
    }

}
