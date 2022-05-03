using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Niveau : MonoBehaviour
{
    public string NomSceneSuivante; 

    public void AllerAuNiveau(){
        SceneManager.LoadScene(NomSceneSuivante);
    } 

    public void OnTriggerEnter(Collider other){
        AllerAuNiveau();
    }
}
