using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

  public void PlayGame()
  {
      SceneManager.LoadScene(("MainMenu"));
  }

  public void PlayNewGame()
  {
        SceneManager.LoadScene(("Lvl1"));
  }




  public void QuitGame()
  {

       // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
  }
   
 
}
