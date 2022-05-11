using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif
namespace StarterAssets {

    public class ItemCollector : MonoBehaviour{

        public static int visitedRockets;
        public static int score;

        [SerializeField] int duration;
        [SerializeField] GameObject quizPanel;
        [SerializeField] GameObject correctAnswer;
        [SerializeField] GameObject wrongAnswer;
        [SerializeField] GameObject timeOver;
        [SerializeField] Image quizTimerFill;
        [SerializeField] Text quizTimerText;
        [SerializeField] Text scoreRocketText;
        StarterAssetsInputs _input;
        bool test;
        float startingTime;
        float currentTime;
        float timeTest;
        bool currentState1;
        bool currentState2;
        bool currentState3;
        bool currentState4;
        bool currentState5;
        bool currentState6;
        bool currentState7;
        bool currentState8;
        

        public void Start(){
            score=0;
            visitedRockets=0;
            _input = GetComponent<StarterAssetsInputs>();
            startingTime=duration;
            currentTime = startingTime;
            timeTest=0f;
            currentState1=false;
            currentState2=false;
            currentState3=false;
            currentState4=false;
            currentState5=false;
            currentState6=false;
            currentState7=false;
            currentState8=false;
            test=false;
        }


        private void Update(){
            if(test){
                timeTest += 1 * Time.deltaTime;
                if(timeTest>=2){
                    test=false;
                    correctAnswer.SetActive(false);
                    wrongAnswer.SetActive(false);
                    timeOver.SetActive(false);
                    timeTest=0f;
                }
            }
            
            if(!GameConfig.endChapterTime){
                if(currentState1)
                    currentState1=QuizResult(currentState1,"1");
                if(currentState2)
                    currentState2=QuizResult(currentState2,"2");
                if(currentState3)
                    currentState3=QuizResult(currentState3,"3");
                if(currentState4)
                    currentState4=QuizResult(currentState4,"1");
                if(currentState5)
                    currentState5=QuizResult(currentState5,"1");
                if(currentState6)
                    currentState6=QuizResult(currentState6,"2");
                if(currentState7)
                    currentState7=QuizResult(currentState7,"1");
                if(currentState8)
                    currentState8=QuizResult(currentState8,"1");
                if (currentTime<=0)
                    QuizTimeOver();
            }
            else
                quizPanel.SetActive(false);
        }

        bool QuizResult(bool currentState, string correct){
            currentTime-=1*Time.deltaTime;
            quizTimerText.text=Mathf.Round(currentTime).ToString();
            quizTimerFill.fillAmount=Mathf.InverseLerp(0,duration,currentTime);
            if((_input.tap1 && !_input.tap2 && !_input.tap3) || (_input.tap2 && !_input.tap1 && !_input.tap3) 
                                                             || (_input.tap3 && !_input.tap2 && !_input.tap1)){
                quizPanel.SetActive(false);
                test=true;
                visitedRockets++;
                currentState=false;
                currentTime=duration;
                FirstPersonController.canMove=true;
            }
            if(_input.tap1 && !_input.tap2 && !_input.tap3 && correct=="1"){
                correctAnswer.SetActive(true);
                score++;
                scoreRocketText.text = "Score : "+score+"/5";
            }
            else if(_input.tap1 && !_input.tap2 && !_input.tap3 && correct!="1")
                wrongAnswer.SetActive(true);
            else if(_input.tap2 && !_input.tap1 && !_input.tap3 && correct=="2"){
                correctAnswer.SetActive(true);
                score++;
                scoreRocketText.text = "Score : "+score+"/5";
            }
            else if(_input.tap2 && !_input.tap1 && !_input.tap3 && correct!="2")
                wrongAnswer.SetActive(true);
            else if(_input.tap3 && !_input.tap2 && !_input.tap1 && correct=="3"){
                correctAnswer.SetActive(true);
                score++;
                scoreRocketText.text = "Score : "+score+"/5";
            }
            else if(_input.tap3 && !_input.tap2 && !_input.tap1 && correct!="3")
                wrongAnswer.SetActive(true);
            return currentState;
        }

        void QuizTimeOver(){
            quizPanel.SetActive(false);
            timeOver.SetActive(true);
            currentTime = duration;
            currentState1 = false;
            currentState2 = false;
            currentState3 = false;
            currentState4 = false;
            currentState5 = false;
            currentState6 = false;
            currentState7 = false;
            currentState8 = false;
            FirstPersonController.canMove=true;
            test=true;
            visitedRockets++;
        }
        

        public void OnTriggerEnter(Collider other){
            if(other.gameObject.CompareTag("rocket1")){
                MakeQuiz("rocket1","How many moons does Mars have?","2\n\nTap 1","3\n\nTap 2","4\n\nTap 3");
                currentState1 = true;
            }
            if(other.gameObject.CompareTag("rocket2")){
                MakeQuiz("rocket2","Ancient people thought the planet\nlooked as red as blood and\nnamed it after their :","Love God\n\nTap 1","War God\n\nTap 2","Water God\n\nTap 3");
                currentState2 = true;
            }
            if(other.gameObject.CompareTag("rocket3")){
                MakeQuiz("rocket3","The right answer is 3","first answer\n\nTap 1","second answer\n\nTap 2","third answer\n\nTap 3");
                currentState3 = true;
            }
            if(other.gameObject.CompareTag("rocket4")){
                MakeQuiz("rocket4","The right answer is 1","first answer\n\nTap 1","second answer\n\nTap 2","third answer\n\nTap 3");
                currentState4 = true;
            }
            if(other.gameObject.CompareTag("rocket5")){
                MakeQuiz("rocket5","The right answer is 1","first answer\n\nTap 1","second answer\n\nTap 2","third answer\n\nTap 3");
                currentState5 = true;
            }
            if(other.gameObject.CompareTag("rocket6")){
                MakeQuiz("rocket6","What is Mars's nickname","Dark planet\n\nTap 1","Red planet\n\nTap 2","Empty planet\n\nTap 3");
                currentState6 = true;
            }
            if(other.gameObject.CompareTag("rocket7")){
                MakeQuiz("rocket7","The right answer is 1","first answer\n\nTap 1","second answer\n\nTap 2","third answer\n\nTap 3");
                currentState7 = true;
            }
            if(other.gameObject.CompareTag("rocket8")){
                MakeQuiz("rocket8","The right answer is 1","first answer\n\nTap 1","second answer\n\nTap 2","third answer\n\nTap 3");
                currentState8 = true;
            }
            if(other.gameObject.CompareTag("rocket9")){
                MakeQuiz("rocket9","aaaaaa","2\n\nTap 1","3\n\nTap 2","4\n\nTap 3");
                currentState1 = true;
            }
            if(other.gameObject.CompareTag("rocket10")){
                MakeQuiz("rocket10","aaaaaa","Love God\n\nTap 1","War God\n\nTap 2","Water God\n\nTap 3");
                currentState2 = true;
            }
            if(other.gameObject.CompareTag("rocket11")){
                MakeQuiz("rocket11","aaaaaa","first answer\n\nTap 1","second answer\n\nTap 2","third answer\n\nTap 3");
                currentState3 = true;
            }
            if(other.gameObject.CompareTag("rocket12")){
                MakeQuiz("rocket12","aaaaaaaaa","first answer\n\nTap 1","second answer\n\nTap 2","third answer\n\nTap 3");
                currentState4 = true;
            }
            if(other.gameObject.CompareTag("rocket13")){
                MakeQuiz("rocket13","aaaaaaaa","first answer\n\nTap 1","second answer\n\nTap 2","third answer\n\nTap 3");
                currentState5 = true;
            }
            if(other.gameObject.CompareTag("rocket14")){
                MakeQuiz("rocket14","aaaaaaaa","Dark planet\n\nTap 1","Red planet\n\nTap 2","Empty planet\n\nTap 3");
                currentState6 = true;
            }
            if(other.gameObject.CompareTag("rocket15")){
                MakeQuiz("rocket15","aaaaaaaaaaaa","first answer\n\nTap 1","second answer\n\nTap 2","third answer\n\nTap 3");
                currentState7 = true;
            }
            if(other.gameObject.CompareTag("rocket16")){
                MakeQuiz("rocket16","aaaaaaaaaaa","first answer\n\nTap 1","second answer\n\nTap 2","third answer\n\nTap 3");
                currentState8 = true;
            }
        }

        void MakeQuiz(string name, string question, string answer1, string answer2, string answer3){
            GameObject.FindGameObjectWithTag(name).SetActive(false);
            FirstPersonController.canMove=false;
            quizPanel.SetActive(true);
            GameObject.FindGameObjectWithTag("questiontext").GetComponent<Text>().text=question;
            GameObject.FindGameObjectWithTag("DialogueBox3").GetComponent<Text>().text=answer1;
            GameObject.FindGameObjectWithTag("DialogueBox4").GetComponent<Text>().text=answer2;
            GameObject.FindGameObjectWithTag("DialogueBox5").GetComponent<Text>().text=answer3;
        }
    }
}
