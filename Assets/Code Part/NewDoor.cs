using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NewDoor : MonoBehaviour
{
    

    

    
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Key"))
        {
           
            SceneManager.LoadScene("level 2");
        }
        
    }
    
    
}
