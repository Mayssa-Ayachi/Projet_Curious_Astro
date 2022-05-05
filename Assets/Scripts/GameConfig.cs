using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace StarterAssets {
    public class GameConfig : MonoBehaviour{

        public static bool isMoon;
        public static bool endChapterTime;
        public static bool endFirstMission;

        [SerializeField] GameObject startImage;
        [SerializeField] int firstMissionDuration;
        [SerializeField] GameObject firstMissionTimer;
        [SerializeField] Image firstMissionTimerFill;
        [SerializeField] Text firstMissionTimerText;
        [SerializeField] GameObject scoreAstro;
        [SerializeField] GameObject secondMission;
        [SerializeField] int secondMissionDuration;
        [SerializeField] GameObject rockets;
        [SerializeField] GameObject secondMissionTimer;
        [SerializeField] Image secondMissionTimerFill;
        [SerializeField] Text secondMissionTimerText;
        [SerializeField] GameObject scoreRocket;
        bool endSecondMission;
        StarterAssetsInputs _input;
        int remainingDuration;
        float timeTest;
        bool a;
        bool b;


        public void Start(){
            _input = GetComponent<StarterAssetsInputs>();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            isMoon = false;
            endChapterTime = false;
            endFirstMission = false;
            endSecondMission = false;
            timeTest = 0f;
            a = true;
            b = true;
        }


        private void Update(){
            if(_input.etkalam && a){
                StartChapter();
                a=false;
            }

            if(endFirstMission && _input.tap1 && b){
                StartMission2();
                b=false;
            }
            
            if(endSecondMission){
                EndChapter();
            }
        }


        void StartChapter(){
            startImage.SetActive(false);
            scoreAstro.SetActive(true);
            firstMissionTimer.SetActive(true);
            FirstPersonController.canMove=true;
            remainingDuration=firstMissionDuration;
            StartCoroutine(UpdateTimer());
        }

        IEnumerator UpdateTimer(){
            while(remainingDuration>=0 && Dialogue.astroCounter<2){
                firstMissionTimerText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                firstMissionTimerFill.fillAmount = Mathf.InverseLerp(0, firstMissionDuration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
                yield return null;
            }
            OnEnd();
        }

        void OnEnd(){
            if(Dialogue.astroCounter == 2){
                // Mission 1 succeeded
                FirstPersonController.canMove=false;
                endFirstMission = true;
                firstMissionTimer.SetActive(false);
                scoreAstro.SetActive(false);
                secondMission.SetActive(true);
            }
            else{
                // Mission 1 time out
                FirstPersonController.canMove=false;
                endChapterTime = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                if(isMoon)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+7);
                else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
            }
        }


        void StartMission2(){
            secondMission.SetActive(false);
            scoreAstro.SetActive(false);
            rockets.SetActive(true);
            scoreRocket.SetActive(true);
            FirstPersonController.canMove=true;
            secondMissionTimer.SetActive(true);
            remainingDuration = secondMissionDuration;
            StartCoroutine(UpdateTimer2());
        }

        IEnumerator UpdateTimer2(){
            while(remainingDuration>=0 && ItemCollector.score<2 && ItemCollector.visitedRockets<3){
                secondMissionTimerText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                secondMissionTimerFill.fillAmount = Mathf.InverseLerp(0, secondMissionDuration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
                yield return null;
            }
            OnEnd2();
        }
       
        void OnEnd2(){
            if(ItemCollector.score==2){
                // Mission 2 succeeded
                FirstPersonController.canMove=false;
                endSecondMission=true;
            }
            else if(ItemCollector.visitedRockets==3){
                // Rockets number over
                FirstPersonController.canMove=false;
                secondMissionTimer.SetActive(false);
                scoreRocket.SetActive(false);
                Cursor.lockState=CursorLockMode.None;
                Cursor.visible=true;
                SceneManager.LoadScene("scoreinf5");
            }
            else{
                // Mission 2 time out
                FirstPersonController.canMove=false;
                endChapterTime=true;
                Cursor.lockState=CursorLockMode.None;
                Cursor.visible=true;
                if(isMoon)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+7);
                else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
               
            }
        }


        void EndChapter(){
            timeTest += 1 * Time.deltaTime;
            if(timeTest>=2){
                secondMissionTimer.SetActive(false);
                scoreRocket.SetActive(false);
                timeTest=0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}