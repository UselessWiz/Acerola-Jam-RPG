using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentController : MonoBehaviour 
{
	[SerializeField] private LSDCamera cameraScript;
	[SerializeField] private LSDHair hair;
    [SerializeField] private GameObject badEndFadeout;
	// WORK OUT WHERE THE HELL AUDIO IS SUPPOSED TO GO

	public void ChangeStage(GameStage stage) 
    {
        // Disable weird components
        cameraScript.enabled = false;
        hair.enabled = false;

        switch (stage) {
            case GameStage.GS_CASTLE: 
            	//hair.enabled = true;// Enable funky hair
            	break;
            case GameStage.GS_GRASSFIELD: 
            	//cameraScript.enabled = true;
            	break;// Enable weird camera plus sounds
            //case GameStage.GS_SCHOOL2: ;// Enable weird music
            case GameStage.GS_BADEND:
                badEndFadeout.SetActive(true);
                break;
            default:
            	break;
        }
    }
}