using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    void Awake()
    {
        SetUpSingleton();
    }
    private void SetUpSingleton()
    {
        int numberGamessions=FindObjectsOfType<GameSession>().Length;
        if(numberGamessions>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
