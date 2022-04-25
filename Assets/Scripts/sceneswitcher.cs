using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneswitcher : MonoBehaviour
{
public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   public void options()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void Back()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2); }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
    public void Howtoplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Gotoplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
       
}

