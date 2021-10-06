using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public GameObject pauseText;
    public bool gamePaused;

    // Use this for initialization
    void Start()
    {
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Taste für Pause erkennen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("pause wurde gedrückt");
            // Methode PauseOrResume
            PauseOrResume();
        }
    }

    public void PauseOrResume()
    {
        // Ist das Spiel derzeit pausiert?
        if (gamePaused)
        {
            // Pause ist aktiviert => Beende die Pause
            Resume();
            // Spiel jetzt pausiert => Variable ändern
            gamePaused = false;
        }
        else
        {
            // Pause nicht aktiviert => Starte die Pause
            Pause();
            // Spiel nicht pausiert => Variable ändern
            gamePaused = true;
        }
    }

    public void Pause()
    {
        // Spiel einfrieren
        Time.timeScale = 0f;
        // Pause text aktivieren
        pauseText.SetActive(true);
    }

    public void Resume()
    {
        // Spiel fortsetzen
        Time.timeScale = 1f;
        // Pause text ausblenden
        pauseText.SetActive(false);
    }
}