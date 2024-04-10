using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;
    private void Start() {
        scoreText=GetComponent<TMP_Text>();
        scoreText.text="Start";
    }
    private void Update() {
        
    }
    public void ScoreIncrease(int amountToIncrease){
        score+=amountToIncrease;
        // Debug.Log($"Score:{score}");
        scoreText.text=score.ToString();
    }
}
