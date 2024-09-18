using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public InputController InputController { get; private set; }

    public GameObject playButton;       // pulsante Play
    public GameObject pauseButton;      // pulsante Pause
    public GameObject pauseMenuPanel;   // Pannello di pausa

    public bool isGameStarted = false;  
    private bool isGamePaused = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InputController = GetComponentInChildren<InputController>();

        // Assicurati che il menu di pausa sia nascosto all'inizio
        pauseMenuPanel.SetActive(false);
    }

    public void StartGame()
    {
        playButton.SetActive(false); 
        isGameStarted = true;        
    }

    public void PauseGame()
    {
        isGamePaused = true;         
        Time.timeScale = 0f;          // Ferma il tempo
        pauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        isGamePaused = false;        
        Time.timeScale = 1f;          // Ripristina il tempo
        pauseMenuPanel.SetActive(false); 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;      
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Ricarica la scena corrente
    }

    public void QuitGame()
    {
        Debug.Log("Quit game!"); 
        Application.Quit();       
    }

    void Update()
    {
        // Verifica se il giocatore preme il pulsante di pausa
        if (Input.GetKeyDown(KeyCode.Escape) && isGameStarted)
        {
            if (isGamePaused)
            {
                ResumeGame();          // se il gioco è in pausa, riprendilo
            }
            else
            {
                PauseGame();           // se il gioco è attivo, mettilo in pausa
            }
        }
    }
}
