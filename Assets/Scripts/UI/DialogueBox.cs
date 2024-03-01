using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI dialogueText;

    public IEnumerator Display(string text, float delay)
    {
        backgroundImage.enabled = true;
        dialogueText.text = text;

        yield return new WaitForSeconds(delay);

        backgroundImage.enabled = false;
        dialogueText.text = "";
    }
}
