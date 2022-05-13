using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace StarterAssets{
    public class sceneswitcher : MonoBehaviour{
        [SerializeField] GameObject finalscene1;
        [SerializeField] GameObject[] audioSource;
        [SerializeField] GameObject slider;
        public static float volume=0.9f;
         int compteur=0;

        public void Start(){
            if(slider!=null)
                slider.GetComponent<Slider>().value=volume;
            if(audioSource!=null)
                for(int i=0;i<audioSource.Length;i++)
                    audioSource[i].GetComponent<AudioSource>().volume=volume;
        }
        public void update(){
            compteur++;
            if(compteur==15);
                    finalscene1.SetActive(false);}
        public void playGame(){
            SceneManager.LoadScene("loading scene");
        }
        public void options(){
            SceneManager.LoadScene("option scene");
        }
        public void Back(){ 
            SceneManager.LoadScene("menu scene"); 
        }
        public void Quit(){
            Application.Quit();
            Debug.Log("Quit!");
        }
        public void Howtoplay(){
            SceneManager.LoadScene("how to play");
        }
        public void Gotoplay(){
            SceneManager.LoadScene("loading scene");
        }
        public void Volume(){
            volume=slider.GetComponent<Slider>().value;
            audioSource[0].GetComponent<AudioSource>().volume=volume;
        }
      
      
    //succes mission mars
        public void backtomenumars(){ 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -9);
        }
        /*public void Gotolab(){//succes mission mars
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
        }*/
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -10);
        }
        public void backtomenu2(){//mta3 lmoon
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -6);
        }
        public void tryagain(){//mta3 scoreinf5 f moon
            if(GameConfig.isMoon)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -6);
            else 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
        }
        public void gomenumoon(){//mta3 scoreinf5 f moon
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -11);
        }
        public void playagainmoon(){//mta3 time out moon
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -7);
        }
        public void backmenumoon(){//mta3 time out moon
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -12);
        }
        public void endingscene(){//won mars
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +4);
                    
        }
    }
}

