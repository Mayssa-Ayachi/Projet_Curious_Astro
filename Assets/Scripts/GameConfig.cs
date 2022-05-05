using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace StarterAssets {
    public class GameConfig : MonoBehaviour , IPointerClickHandler
    {
        public GameObject timerAstro;
        public GameObject timerRockets;
        public static bool endGameTime = false;
        public static bool endMission1 = false;
        public static bool endMission2 = false;
        public GameObject startImage;
        public GameObject scoreAstro;
        public GameObject rockets;
        public GameObject scoreImage;
        public GameObject mission2;
        [SerializeField] private Image TimerAstroFill;
        [SerializeField] private Text TimerAstroText;
        [SerializeField] private Image TimerRocketsFill;
        [SerializeField] private Text TimerRocketsText;
        public int Duration;
        public int Duration2;
        private StarterAssetsInputs _input;
        bool a = true;
        bool b = true;
        bool c = true;
        private int remainingDuration;
        private bool Pause;
        float timeTest = 0f;
        public static bool isMoon=false;

        public void OnPointerClick(PointerEventData eventData)
        {
            Pause = !Pause;
        }

        private void Start()
        {
            Dialogue.astroCounter=0;
            ItemCollector.score=0;
            ItemCollector.visitedRockets=0;
            _input = GetComponent<StarterAssetsInputs>();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }

        private void Update(){
            if(_input.etkalam && a){
                startImage.SetActive(false);
                scoreAstro.SetActive(true);
                timerAstro.SetActive(true);
                FirstPersonController.canMove=true;
                Being(Duration);
                a=false;
            }
            if(endMission1 && _input.tap1 && b){
                mission2.SetActive(false);
                scoreAstro.SetActive(false);
                rockets.SetActive(true);
                scoreImage.SetActive(true);
                FirstPersonController.canMove=true;
                b=false;

                // bch ybde mission2
                timerRockets.SetActive(true);
                Being2(Duration2);
            }

            if(endMission2 && c){
                timeTest += 1 * Time.deltaTime;
                if(timeTest>=2){
                    c=false;
                    timerRockets.SetActive(false);
                    scoreImage.SetActive(false);
                    timeTest=0f;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    //mission3.SetActive(true);
                }
            }
        }

        private void Being(int Second)
        {
            remainingDuration = Second;
            StartCoroutine(UpdateTimer());
        }

        private IEnumerator UpdateTimer()
        {
            while(remainingDuration >= 0 && Dialogue.astroCounter<2)
            {
                if (!Pause)
                {
                    TimerAstroText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                    TimerAstroFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                    remainingDuration--;
                    yield return new WaitForSeconds(1f);
                }
                yield return null;
            }
            OnEnd();
        }

        private void OnEnd()
        {
            if(Dialogue.astroCounter == 2){
                endMission1 = true;
                // eli chyet3mal ki ykamal etache loula
                FirstPersonController.canMove=false;
                timerAstro.SetActive(false);
                scoreAstro.SetActive(false);
                mission2.SetActive(true);
            }
            else{
                // eli chyet3mal ki youfa wa9t etache loula
                FirstPersonController.canMove=false;
                endGameTime = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                if(isMoon)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
                else
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }

        private void Being2(int Second)
        {
            remainingDuration = Second;
            StartCoroutine(UpdateTimer2());
        }

        private IEnumerator UpdateTimer2()
        {
            while(remainingDuration >= 0 && ItemCollector.score<2 && ItemCollector.visitedRockets<3)
            {
                if (!Pause)
                {
                    TimerRocketsText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                    TimerRocketsFill.fillAmount = Mathf.InverseLerp(0, Duration2, remainingDuration);
                    remainingDuration--;
                    yield return new WaitForSeconds(1f);
                }
                yield return null;
            }
            OnEnd2();
        }
       
        private void OnEnd2()
        {
            if(ItemCollector.score == 2){
                // eli chyet3mal ki ykamal etache ethenya
                FirstPersonController.canMove=false;
                endMission2=true;
                //leb9ia fel update
            }
            else if(ItemCollector.visitedRockets==3){
                //eli chyet3mal ki youfaw rockets etache ethenya whoua mejebch 5
                FirstPersonController.canMove=false;
                timerRockets.SetActive(false);
                scoreImage.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("scoreinf5");
            }
            else{
                // eli chyet3mal ki youfa wa9t etache ethenya
                FirstPersonController.canMove=false;
                endGameTime = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }
    }
}