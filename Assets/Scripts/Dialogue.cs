

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public DialogueSO dialogueSO;
    public bool isOnDial = false;
    public int currentDialogue;
    Text textBox;
    public GameObject scoreAstro ;
    [SerializeField] Text scoreAstroText;
    public static int count = 0;
    bool once1=true;
    bool once2=true;
    bool once3=true;
    bool once4=true;
    bool once5=true;

    
    public void StartDialogue()
    {
        textBox = GameObject.FindGameObjectWithTag("DialogueBox1").GetComponent<Text>();
        textBox.text = dialogueSO.dialogue[currentDialogue];
        isOnDial = true;
    }
    /*
    public void StartDialogue2()
    {
        textBox = GameObject.FindGameObjectWithTag("DialogueBox2").GetComponent<Text>();
        textBox.text = dialogueSO.dialogue[currentDialogue];
        isOnDial = true;   
    }

    public void StartDialogue3()
    {
        textBox = GameObject.FindGameObjectWithTag("DialogueBox3").GetComponent<Text>();
        textBox.text = dialogueSO.dialogue[currentDialogue];
        isOnDial = true;   
    }

    public void StartDialogue4()
    {
        textBox = GameObject.FindGameObjectWithTag("DialogueBox4").GetComponent<Text>();
        textBox.text = dialogueSO.dialogue[currentDialogue];
        isOnDial = true;   
    }

    public void StartDialogue5()
    {
        textBox = GameObject.FindGameObjectWithTag("DialogueBox5").GetComponent<Text>();
        textBox.text = dialogueSO.dialogue[currentDialogue];
        isOnDial = true;   
    }

    */

    public void NextLine()
    {
	    if(isOnDial && currentDialogue != dialogueSO.dialogue.Length - 1)
	    {
		    currentDialogue++;
		    textBox.text = dialogueSO.dialogue[currentDialogue];
	    }else if(isOnDial && currentDialogue == dialogueSO.dialogue.Length - 1)
	    {
		    isOnDial = false;
		    currentDialogue = 0;
		    textBox.text = "";
            
            if(once1){
                if(dialogueSO.dialogue[0]=="Hello my name is Yeils"){count++;scoreAstroText.text = "Astronaut : "+count+"/5";}
                    once1=false;
            }
            if(once2){
                if(dialogueSO.dialogue[0]=="hello king"){count++;scoreAstroText.text = "Astronaut : "+count+"/5";}
                    once2=false;
            }
            if(once3){
                if(dialogueSO.dialogue[0]=="Hello my name is Martina"){count++;scoreAstroText.text = "Astronaut : "+count+"/5";}
                    once3=false;
            }
            if(once4){
                if(dialogueSO.dialogue[0]=="azeerr"){count++;scoreAstroText.text = "Astronaut : "+count+"/5";}
                    once4=false;
            }
            if(once5){
                if(dialogueSO.dialogue[0]=="dlfknvefd"){count++;scoreAstroText.text = "Astronaut : "+count+"/5";}
                    once5=false;
            }
        }
    }
}