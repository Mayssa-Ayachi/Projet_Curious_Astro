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
    public static int astro_counter = 0;
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
                if(dialogueSO.dialogue[0]=="Hello my name is Yeils"){astro_counter++;scoreAstroText.text = "Astronaut : "+astro_counter+"/5";}
                    once1=false;
            }
            if(once2){
                if(dialogueSO.dialogue[0]=="hello king"){astro_counter++;scoreAstroText.text = "Astronaut : "+astro_counter+"/5";}
                    once2=false;
            }
            if(once3){
                if(dialogueSO.dialogue[0]=="Hello my name is Martina"){astro_counter++;scoreAstroText.text = "Astronaut : "+astro_counter+"/5";}
                    once3=false;
            }
            if(once4){
                if(dialogueSO.dialogue[0]=="azeerr"){astro_counter++;scoreAstroText.text = "Astronaut : "+astro_counter+"/5";}
                    once4=false;
            }
            if(once5){
                if(dialogueSO.dialogue[0]=="dlfknvefd"){astro_counter++;scoreAstroText.text = "Astronaut : "+astro_counter+"/5";}
                    once5=false;
            }
        }
    }
}