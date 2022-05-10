using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    int score;
    

  
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }
    public void ChangeScore(int coinValue)
    {
        score +=coinValue;
        scoreText.text = ""+score.ToString();
       

        
    
    }
   
    
    
}
