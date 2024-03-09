using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private MovementController playerScript;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Canvas canvas;

    public IEnumerator Display(string text, float delay, Vector2 location = new Vector2(), float timeBetweenLetters = 0.05f)
    {
        Debug.Log("display workd");
        playerScript.dialogueFinished = false;

        if (location == default(Vector2)) {
            transform.position = new Vector2(100, 50);
        }
        else {
            transform.position = location;
        }

        transform.position = transform.position + canvas.transform.position;

        backgroundImage.enabled = true;

        for (int i = 0; i < text.Length; i++) {
            dialogueText.text = dialogueText.text + text[i];
            yield return new WaitForSeconds(timeBetweenLetters);
        }

        yield return new WaitForSeconds(delay);

        backgroundImage.enabled = false;
        dialogueText.text = "";
        playerScript.dialogueFinished = true;
    }
}
