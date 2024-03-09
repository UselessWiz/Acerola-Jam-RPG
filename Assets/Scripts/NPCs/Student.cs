using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    [SerializeField] private DialogueContainer dialogueContainer;
    [SerializeField] private bool random;

    public float delay = 2f;
    
    //[SerializeField] private bool dialogueSaid = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public string GetDialogue()
    {
        gameObject.GetComponent<Collider2D>().enabled = false; 

        if (random) {
            return dialogueContainer.SelectRandomDialogue();
        }
        else {
            return dialogueContainer.NextSequentialDialogue();
        }
    }
}
