using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace StarterAssets{
public class sceneswitcher : MonoBehaviour
{
public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   public void options()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void Back()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3); }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
      
      
    //succes mission mars
    public void backtomenumars(){ 
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -9);
    }
    public void Gotolab(){//succes mission mars
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }
     public void unlockmars(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
     }
     public void retry(){
        if(GameConfig.isMoon)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -5);
        else 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
        }
      public void backtomenu(){//mt3 mars
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -10);}
       public void backtomenu2(){//mta3 lmoon
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -6);}
      public void tryagain(){//mta3 scoreinf5 f moon
      if(GameConfig.isMoon)
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -6);
      else 
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);}
      public void gomenumoon(){//mta3 scoreinf5 f moon
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -11);}
      public void playagainmoon(){//mta3 time out moon
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -7);}
      public void backmenumoon(){//mta3 time out moon
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -12);}

}
}

