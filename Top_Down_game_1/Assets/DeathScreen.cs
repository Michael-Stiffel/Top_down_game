using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathScreen : MonoBehaviour
{
  

    public GameObject DeathScreeUI;
    public Player player;

    void Update()
    {
        if (player.currentHealth <= 0)
        {
            Pause();
        }
    }
    
    
    public void Pause()
    {
        DeathScreeUI.SetActive(true);
      
     
    }

    public void LoadMenu()
    {
       
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
