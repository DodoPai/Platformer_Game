using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator animes;
    public Text nameText;
    public Text diaalogueText;
    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
        
    }
    public void StartDialogue(Dialogue dialogue)
    {
        animes.SetBool("IsOpen",true);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        diaalogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            diaalogueText.text +=letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
         animes.SetBool("IsOpen",false);
    }

    
}
