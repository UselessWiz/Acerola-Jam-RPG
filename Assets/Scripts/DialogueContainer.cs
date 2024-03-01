using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueContainer : ScriptableObject
{
	[SerializeField] private List<string> dialogueLines = new List<string>();

	// Used for Specific instances of NPC dialogue.
	// The variable relevantNPC is used solely to identify the NPC; it is not used in code, this is intentional.
	[SerializeField] private int currentDialogueIndex = 0;
	[SerializeField] private GameObject relevantNPC;

	public string SelectRandomDialogue()
	{
		return dialogueLines[UnityEngine.Random.Range(0, dialogueLines.Count)];
	}

	public string NextSequentialDialogue()
	{
		currentDialogueIndex += 1;
		return dialogueLines[currentDialogueIndex - 1];
	}
}