using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {
    
    public static int astroCounter;
    public string[] dialogue;
    public bool isTalking;

    [SerializeField] Text scoreAstroText;
    int dialogueIndex;
    Image imageBox;
    Text textBox;
    bool once1=true;
    bool once2=true;
    bool once3=true;
    bool once4=true;
    bool once5=true;


    public void Start(){
        astroCounter=0;
        imageBox=GameObject.FindGameObjectWithTag("ImageBox1").GetComponent<Image>();
        textBox=GameObject.FindGameObjectWithTag("DialogueBox1").GetComponent<Text>();
    }

    public void Initialize(){
        isTalking=false;
        dialogueIndex=0;
        imageBox.enabled=false;
        textBox.text="";
    }    

    public void StartDialogue(){
        imageBox.enabled=true;
        textBox.text=dialogue[dialogueIndex];
        isTalking=true;
    }

    public void NextLine(){
	    if(isTalking && (dialogueIndex!=dialogue.Length-1)){
		    dialogueIndex++;
		    textBox.text=dialogue[dialogueIndex];
	    }
        else if(isTalking && (dialogueIndex==dialogue.Length-1)){
            
		    Initialize();
            
            if(dialogue[0]=="Hello my name is Yeils" && once1){
                astroCounter++;
                scoreAstroText.text = "Astronaut : "+astroCounter+"/5";
                once1=false;
            }
            
            if(dialogue[0]=="hello king" && once2){
                astroCounter++;
                scoreAstroText.text = "Astronaut : "+astroCounter+"/5";
                once2=false;
            }
                    
            if(dialogue[0]=="Hello my name is Martina" && once3){
                astroCounter++;
                scoreAstroText.text = "Astronaut : "+astroCounter+"/5";
                once3=false;
            }
            
            if(dialogue[0]=="azeerr" && once4){
                astroCounter++;
                scoreAstroText.text = "Astronaut : "+astroCounter+"/5";
                once4=false;
            }
                    
            if(dialogue[0]=="dlfknvefd" && once5){
                astroCounter++;
                scoreAstroText.text = "Astronaut : "+astroCounter+"/5";
                once5=false;
            }
        }
    }
}