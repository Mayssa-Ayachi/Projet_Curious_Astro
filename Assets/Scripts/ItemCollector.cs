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

        bool currentState9;
        bool currentState10;
        bool currentState11;
        bool currentState12;
        bool currentState13;
        bool currentState14;
        bool currentState15;
        bool currentState16;
        

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

            currentState9=false;
            currentState10=false;
            currentState11=false;
            currentState12=false;
            currentState13=false;
            currentState14=false;
            currentState15=false;
            currentState16=false;
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
                    currentState3=QuizResult(currentState3,"2");
                if(currentState4)
                    currentState4=QuizResult(currentState4,"3");
                if(currentState5)
                    currentState5=QuizResult(currentState5,"2");
                if(currentState6)
                    currentState6=QuizResult(currentState6,"1");
                if(currentState7)
                    currentState7=QuizResult(currentState7,"1");
                if(currentState8)
                    currentState8=QuizResult(currentState8,"1");
                
                if(currentState9)
                    currentState9=QuizResult(currentState1,"1");
                if(currentState10)
                    currentState10=QuizResult(currentState2,"3");
                if(currentState11)
                    currentState11=QuizResult(currentState3,"3");
                if(currentState12)
                    currentState12=QuizResult(currentState4,"2");
                if(currentState13)
                    currentState13=QuizResult(currentState5,"2");
                if(currentState14)
                    currentState14=QuizResult(currentState6,"1");
                if(currentState15)
                    currentState15=QuizResult(currentState7,"1");
                if(currentState16)
                    currentState16=QuizResult(currentState8,"3");

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
                MakeQuiz("rocket1","Does scientists find evidence of\nliquid water on Mars?","Yes\n\nTap 1","No\n\nTap 2","Not yet\n\nTap 3");
                currentState1 = true;
            }
            if(other.gameObject.CompareTag("rocket2")){
                MakeQuiz("rocket2","What color is the Martian\nsky during the day?","Orange\n\nTap 1","Butterscotch\n\nTap 2","Turquoise\n\nTap 3");
                currentState2 = true;
            }
            if(other.gameObject.CompareTag("rocket3")){
                MakeQuiz("rocket3","About how long would it take\nto travel to Mars?","A month\n\nTap 1","Eight months\n\nTap 2","Two years\n\nTap 3");
                currentState3 = true;
            }
            if(other.gameObject.CompareTag("rocket4")){
                MakeQuiz("rocket4","What's Mars's nickname?","hot planet\n\nTap 1","dark planet\n\nTap 2","red planet\n\nTap 3");
                currentState4 = true;
            }
            if(other.gameObject.CompareTag("rocket5")){
                MakeQuiz("rocket5","Mars is the _____\nplanet from the sun.","Third\n\nTap 1","Fourth\n\nTap 2","Sixth\n\nTap 3");
                currentState5 = true;
            }
            if(other.gameObject.CompareTag("rocket6")){
                MakeQuiz("rocket6","Does Mars have the largest volcano\nin the solar system?","Yes\n\nTap 1","No\n\nTap 2","Mars doesn't contain\na volcano\n\nTap 3");
                currentState6 = true;
            }
            if(other.gameObject.CompareTag("rocket7")){
                MakeQuiz("rocket7","How many people have walked\non Mars?","0\n\nTap 1","2\n\nTap 2","3\n\nTap 3");
                currentState7 = true;
            }
            if(other.gameObject.CompareTag("rocket8")){
                MakeQuiz("rocket8","How many moons does\nMars have?","2\n\nTap 1","4\n\nTap 2","8\n\nTap 3");
                currentState8 = true;
            }
            
            if(other.gameObject.CompareTag("rocket9")){
                MakeQuiz("rocket9","Duration of moon's revolution\naround the earth:","27 earth days\n\nTap 1","12 earth hours\n\nTap 2","one earth year\n\nTap 3");
                currentState9 = true;
            }
            if(other.gameObject.CompareTag("rocket10")){
                MakeQuiz("rocket10","A day in the moon is equivalent\nin earth to:","24 hours\n\nTap 1","5 earth days\n\nTap 2","27 earth days\n\nTap 3");
                currentState10 = true;
            }
            if(other.gameObject.CompareTag("rocket11")){
                MakeQuiz("rocket11","What is the moon's atmosphere made of?","Oxygen\n\nTap 1","Nitrogen\n\nTap 2","Nothing\n\nTap 3");
                currentState11 = true;
            }
            if(other.gameObject.CompareTag("rocket12")){
                MakeQuiz("rocket12","What phenomenon does the moon affect\non earth?","The seasons\n\nTap 1","The tides\n\nTap 2","Mountain erosion\n\nTap 3");
                currentState12 = true;
            }
            if(other.gameObject.CompareTag("rocket13")){
                MakeQuiz("rocket13","What do many astronomers think\ncaused the information of the moon?","A comet\n\nTap 1","An asteroid\n\nTap 2","The sun\n\nTap 3");
                currentState13 = true;
            }
            if(other.gameObject.CompareTag("rocket14")){
                MakeQuiz("rocket14","How old is the moon?","5.4 million years\n\nTap 1","4.5 billion years\n\nTap 2","10 billion years\n\nTap 3");
                currentState14 = true;
            }
            if(other.gameObject.CompareTag("rocket15")){
                MakeQuiz("rocket15","What causes the moon to shine?","The sun\n\nTap 1","Electricity\n\nTap 2","Pixie dust\n\nTap 3");
                currentState15 = true;
            }
            if(other.gameObject.CompareTag("rocket16")){
                MakeQuiz("rocket16","Which planet has the largest moon?","Earth\n\nTap 1","Mars\n\nTap 2","Jupiter\n\nTap 3");
                currentState16 = true;
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
