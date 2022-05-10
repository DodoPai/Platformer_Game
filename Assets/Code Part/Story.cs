using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public Dialogue dialogue;

    public void storypart()
    {
        //objeyi bul sonunda fonksiyon yaz.fonksiyonun anlamı olsun.
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        

    }
    
    
}
