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
    public void Next(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
 
    }   
    public void Gotolab(){
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
  public void retry(){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);}
      public void backtomenu(){//mt3 mars
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -10);}
       public void backtomenu2(){//mta3 lmoon
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -6);}
      public void tryagain(){//mta3 scoreinf5 f moon
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -6);}
      public void gomenumoon(){//mta3 scoreinf5 f moon
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -11);}


}

