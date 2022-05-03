using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif
namespace StarterAssets {

    public class ItemCollector : MonoBehaviour
    {
        private StarterAssetsInputs _input;
        public GameObject obj;
        public GameObject win;
        public GameObject loose;
        public GameObject timeOver;
        float currentTime;
        private float startingTime = 30f;
        public static int visitedRockets = 0;
        bool currentState1=false;
        bool currentState2=false;
        bool currentState3=false;
        bool currentState4=false;
        bool currentState5=false;
        bool currentState6=false;
        bool currentState7=false;
        bool currentState8=false;
        public static int score=0;
        bool test=false;
        float timeTest = 0f; 
        public int Duration;
        [SerializeField] private Image uiFill;
        [SerializeField] Text countdownText;
        [SerializeField] Text scoreText;

        void Start(){
           GameConfig.endMission1=false;
           GameConfig.endMission2=false;
           GameConfig.endGameTime=false;
           ItemCollector.visitedRockets=0;
            _input = GetComponent<StarterAssetsInputs>();
            currentTime = startingTime;
        }
        void Update(){
            
            if(test){
                timeTest += 1 * Time.deltaTime;
                if(timeTest>=2){
                    test=false;
                    win.SetActive(false);
                    loose.SetActive(false);
                    timeOver.SetActive(false);
                    timeTest=0f;
                }
            }
            if(!GameConfig.endGameTime){
            if(currentState1){
                currentTime -= 1 * Time.deltaTime;
                countdownText.text = Mathf.Round(currentTime).ToString();
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, currentTime);
                if(_input.tap1){
                    currentState1=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    win.SetActive(true);
                    test=true;
                    score++;
                    scoreText.text = "Score : "+score+"/5";
                    visitedRockets++;
                }
                if(_input.tap2){
                    currentState1=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap3){
                    currentState1=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
            }

            if(currentState2){
                currentTime -= 1 * Time.deltaTime;
                countdownText.text = Mathf.Round(currentTime).ToString();
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, currentTime);
                if(_input.tap2){
                    currentState2=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    win.SetActive(true);
                    score++;
                    scoreText.text = "Score : "+score+"/5";
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap1){
                    currentState2=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap3){
                    currentState2=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
            }

            if(currentState3){
                currentTime -= 1 * Time.deltaTime;
                countdownText.text = Mathf.Round(currentTime).ToString();
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, currentTime);
                if(_input.tap3){
                    currentState3=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    win.SetActive(true);
                    score++;
                    scoreText.text = "Score : "+score+"/5";
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap2){
                    currentState3=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap1){
                    currentState3=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
            }

            if(currentState4){
                currentTime -= 1 * Time.deltaTime;
                countdownText.text = Mathf.Round(currentTime).ToString();
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, currentTime);
                if(_input.tap1){
                    currentState4=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    win.SetActive(true);
                    score++;
                    scoreText.text = "Score : "+score+"/5";
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap2){
                    currentState4=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap3){
                    currentState4=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
            }

            if(currentState5){
                currentTime -= 1 * Time.deltaTime;
                countdownText.text = Mathf.Round(currentTime).ToString();
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, currentTime);
                if(_input.tap1){
                    currentState5=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    win.SetActive(true);
                    score++;
                    scoreText.text = "Score : "+score+"/5";
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap2){
                    currentState5=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap3){
                    currentState5=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
            }

            if(currentState6){
                currentTime -= 1 * Time.deltaTime;
                countdownText.text = Mathf.Round(currentTime).ToString();
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, currentTime);
                if(_input.tap2){
                    currentState6=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    win.SetActive(true);
                    score++;
                    scoreText.text = "Score : "+score+"/5";
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap1){
                    currentState6=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap3){
                    currentState6=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
            }

            if(currentState7){
                currentTime -= 1 * Time.deltaTime;
                countdownText.text = Mathf.Round(currentTime).ToString();
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, currentTime);
                if(_input.tap1){
                    currentState7=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    win.SetActive(true);
                    score++;
                    scoreText.text = "Score : "+score+"/5";
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap2){
                    currentState7=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap3){
                    currentState7=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
            }

            if(currentState8){
                currentTime -= 1 * Time.deltaTime;
                countdownText.text = Mathf.Round(currentTime).ToString();
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, currentTime);
                if(_input.tap1){
                    currentState8=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    win.SetActive(true);
                    score++;
                    scoreText.text = "Score : "+score+"/5";
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap2){
                    currentState8=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
                if(_input.tap3){
                    currentState8=false;
                    currentTime=30f;
                    obj.SetActive(false);
                    FirstPersonController.canMove=true;
                    loose.SetActive(true);
                    test=true;
                    visitedRockets++;
                }
            }
            if (currentTime <= 0){
                currentTime = 30f;
                currentState1 = false;
                currentState2 = false;
                currentState3 = false;
                currentState4 = false;
                currentState5 = false;
                currentState6 = false;
                currentState7 = false;
                currentState8 = false;
                obj.SetActive(false);
                FirstPersonController.canMove=true;
                timeOver.SetActive(true);
                test=true;
                visitedRockets++;
            }
            }
            else
                obj.SetActive(false);
        }

        public void OnTriggerEnter(Collider other){
            if(other.gameObject.CompareTag("rocket1")){
                GameObject.FindGameObjectWithTag("rocket1").SetActive(false);
                FirstPersonController.canMove=false;
                obj.SetActive(true);
                GameObject.FindGameObjectWithTag("questiontext").GetComponent<Text>().text="How many moons does Mars have?";
                GameObject.FindGameObjectWithTag("DialogueBox3").GetComponent<Text>().text="2\n\nTap 1";
                GameObject.FindGameObjectWithTag("DialogueBox4").GetComponent<Text>().text="3\n\nTap 2";
                GameObject.FindGameObjectWithTag("DialogueBox5").GetComponent<Text>().text="4\n\nTap 3";
                currentState1 = true;
            }
            if(other.gameObject.CompareTag("rocket2")){
                GameObject.FindGameObjectWithTag("rocket2").SetActive(false);
                FirstPersonController.canMove=false;
                obj.SetActive(true);
                GameObject.FindGameObjectWithTag("questiontext").GetComponent<Text>().text="Ancient people thought the planet\nlooked as red as blood and\nnamed it after their :";
                GameObject.FindGameObjectWithTag("DialogueBox3").GetComponent<Text>().text="Love God\n\nTap 1";
                GameObject.FindGameObjectWithTag("DialogueBox4").GetComponent<Text>().text="War God\n\nTap 2";
                GameObject.FindGameObjectWithTag("DialogueBox5").GetComponent<Text>().text="Water God\n\nTap 3";
                currentState2 = true;
            }
            if(other.gameObject.CompareTag("rocket3")){
                GameObject.FindGameObjectWithTag("rocket3").SetActive(false);
                FirstPersonController.canMove=false;
                obj.SetActive(true);
                GameObject.FindGameObjectWithTag("questiontext").GetComponent<Text>().text="The right answer is 3";
                GameObject.FindGameObjectWithTag("DialogueBox3").GetComponent<Text>().text="first answer\n\nTap 1";
                GameObject.FindGameObjectWithTag("DialogueBox4").GetComponent<Text>().text="second answer\n\nTap 2";
                GameObject.FindGameObjectWithTag("DialogueBox5").GetComponent<Text>().text="third answer\n\nTap 3";
                currentState3 = true;
            }
            if(other.gameObject.CompareTag("rocket4")){
                GameObject.FindGameObjectWithTag("rocket4").SetActive(false);
                FirstPersonController.canMove=false;
                obj.SetActive(true);
                GameObject.FindGameObjectWithTag("questiontext").GetComponent<Text>().text="The right answer is 1";
                GameObject.FindGameObjectWithTag("DialogueBox3").GetComponent<Text>().text="first answer\n\nTap 1";
                GameObject.FindGameObjectWithTag("DialogueBox4").GetComponent<Text>().text="second answer\n\nTap 2";
                GameObject.FindGameObjectWithTag("DialogueBox5").GetComponent<Text>().text="third answer\n\nTap 3";
                currentState4 = true;
            }
            if(other.gameObject.CompareTag("rocket5")){
                GameObject.FindGameObjectWithTag("rocket5").SetActive(false);
                FirstPersonController.canMove=false;
                obj.SetActive(true);
                GameObject.FindGameObjectWithTag("questiontext").GetComponent<Text>().text="The right answer is 1";
                GameObject.FindGameObjectWithTag("DialogueBox3").GetComponent<Text>().text="first answer\n\nTap 1";
                GameObject.FindGameObjectWithTag("DialogueBox4").GetComponent<Text>().text="second answer\n\nTap 2";
                GameObject.FindGameObjectWithTag("DialogueBox5").GetComponent<Text>().text="third answer\n\nTap 3";
                currentState5 = true;
            }
            if(other.gameObject.CompareTag("rocket6")){
                GameObject.FindGameObjectWithTag("rocket6").SetActive(false);
                FirstPersonController.canMove=false;
                obj.SetActive(true);
                GameObject.FindGameObjectWithTag("questiontext").GetComponent<Text>().text="What is Mars's nickname";
                GameObject.FindGameObjectWithTag("DialogueBox3").GetComponent<Text>().text="Dark planet\n\nTap 1";
                GameObject.FindGameObjectWithTag("DialogueBox4").GetComponent<Text>().text="Red planet\n\nTap 2";
                GameObject.FindGameObjectWithTag("DialogueBox5").GetComponent<Text>().text="Empty planet\n\nTap 3";
                currentState6 = true;
            }
            if(other.gameObject.CompareTag("rocket7")){
                GameObject.FindGameObjectWithTag("rocket7").SetActive(false);
                FirstPersonController.canMove=false;
                obj.SetActive(true);
                GameObject.FindGameObjectWithTag("questiontext").GetComponent<Text>().text="The right answer is 1";
                GameObject.FindGameObjectWithTag("DialogueBox3").GetComponent<Text>().text="first answer\n\nTap 1";
                GameObject.FindGameObjectWithTag("DialogueBox4").GetComponent<Text>().text="second answer\n\nTap 2";
                GameObject.FindGameObjectWithTag("DialogueBox5").GetComponent<Text>().text="third answer\n\nTap 3";
                currentState7 = true;
            }
            if(other.gameObject.CompareTag("rocket8")){
                GameObject.FindGameObjectWithTag("rocket8").SetActive(false);
                FirstPersonController.canMove=false;
                obj.SetActive(true);
                GameObject.FindGameObjectWithTag("questiontext").GetComponent<Text>().text="The right answer is 1";
                GameObject.FindGameObjectWithTag("DialogueBox3").GetComponent<Text>().text="first answer\n\nTap 1";
                GameObject.FindGameObjectWithTag("DialogueBox4").GetComponent<Text>().text="second answer\n\nTap 2";
                GameObject.FindGameObjectWithTag("DialogueBox5").GetComponent<Text>().text="third answer\n\nTap 3";
                currentState8 = true;
            }
        }
    }
}
