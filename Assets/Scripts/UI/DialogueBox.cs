using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Canvas canvas;

    public IEnumerator Display(string text, float delay, Vector2 location = new Vector2())
    {
        if (location == default(Vector2)) {
            transform.position = new Vector2(100, 50);
        }
        else {
            transform.position = location;
        }

        transform.position = transform.position + canvas.transform.position;

        backgroundImage.enabled = true;
        dialogueText.text = text;

        yield return new WaitForSeconds(delay);

        backgroundImage.enabled = false;
        dialogueText.text = "";
    }
}
