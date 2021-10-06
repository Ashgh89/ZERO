using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{

    private bool gamePaused;
    public GameObject pauseMenuUI;

   
  

    void Start()
    {
        pauseMenuUI.SetActive(false);
       
    }

    

    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
                Resume();
            
               
            else
               Pause();

        }


    }
    
     

    public void Resume()
    {

        pauseMenuUI.SetActive(false);
        gamePaused = false;
       // Cursor.visible = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;

        AudioListener.pause = false;


    }
            

    public void Pause()
    {
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        gamePaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        
        
    }
            

}   
     


                
            



        

  
