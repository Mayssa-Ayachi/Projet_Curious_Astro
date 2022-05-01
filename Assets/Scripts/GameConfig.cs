using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace StarterAssets {
    public class GameConfig : MonoBehaviour , IPointerClickHandler
    {
        public string scenename;
        public GameObject timerAstro;
        public GameObject timerRockets;
        public GameObject timeAstroOver;
        public GameObject recketsOver;
        public static bool endGameTime = false;
        public static bool endMission1 = false;
        public static bool endMission2 = false;
        public GameObject startText;
        public GameObject scoreAstro;
        public GameObject rockets;
        public GameObject scoreImage;
        public GameObject mission2;
        public GameObject mission3;
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
            Dialogue.count=0;
            ItemCollector.score=0;
            ItemCollector.visitedReckets=0;
            _input = GetComponent<StarterAssetsInputs>();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;//false ?
        }

        private void Update(){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;//3leh fel update ??
            if(_input.etkalam && a){
                startText.SetActive(false);
                scoreAstro.SetActive(true);
                timerAstro.SetActive(true);
                FirstPersonController.changeMove(true);
                Being(Duration);
                a=false;
            }
            if(endMission1 && _input.tap1 && b){
                mission2.SetActive(false);
                scoreAstro.SetActive(false);
                rockets.SetActive(true);
                scoreImage.SetActive(true);
                FirstPersonController.changeMove(true);
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
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    //mission3.SetActive(true);
                    timeTest=0f;
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
            while(remainingDuration >= 0 && Dialogue.count<2)
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
            if(Dialogue.count == 2){
                endMission1 = true;
                // eli chyet3mal ki ykamal etache loula
                FirstPersonController.changeMove(false);
                timerAstro.SetActive(false);
                scoreAstro.SetActive(false);
                mission2.SetActive(true);
            }
            else{
                // eli chyet3mal ki youfa wa9t etache loula
                FirstPersonController.changeMove(false);
                endGameTime = true;
                if(isMoon)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
                else
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

                //timeAstroOver.SetActive(true);// 3leh mne7ia
            }
        }
        public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

        private void Being2(int Second)
        {
            remainingDuration = Second;
            StartCoroutine(UpdateTimer2());
        }

        private IEnumerator UpdateTimer2()
        {
            while(remainingDuration >= 0 && ItemCollector.score<2 && ItemCollector.visitedReckets<3)
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
                FirstPersonController.changeMove(false);
                endMission2=true;
                //leb9ia fel update
            }
            else if(ItemCollector.visitedReckets==3){
                // eli chyet3mal ki youfaw reckets etache ethenya whoua mejebch 5
                FirstPersonController.changeMove(false);
                timerRockets.SetActive(false);
                scoreImage.SetActive(false);
                LoadScene("scoreinf5");
                //recketsOver.SetActive(true);
                
            }
            else{
                // eli chyet3mal ki youfa wa9t etache ethenya
                FirstPersonController.changeMove(false);
                endGameTime = true;
               // LoadScene("time over lost");
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                //timeAstroOver.SetActive(true);
            }
        }
    }
}