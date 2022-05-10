using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
   public int health = 6;
   public TextMeshProUGUI healthtext;
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
           health -=1;
            
        }
    }
   
    void Update()
    {
        healthtext.text = health.ToString();
        if(health<=0)
        {
            SceneManager.LoadScene("gameover");
        }
    }
    public void ChangeHealth()
    {
        health -=1;
        healthtext.text = ""+health.ToString();

    }
   
}
