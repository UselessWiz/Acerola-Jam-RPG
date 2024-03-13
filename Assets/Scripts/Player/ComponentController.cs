using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentController : MonoBehaviour 
{
    [SerializeField] private GameObject school2bg;
    [SerializeField] private GameObject badEndFadeout;

	public void ChangeStage(GameStage stage) 
    {
        // Disable weird components
        school2bg.SetActive(false);

        switch (stage) {
            case GameStage.GS_CASTLE: 
            	//hair.enabled = true;// Enable funky hair
            	break;
            case GameStage.GS_GRASSFIELD: 
            	//cameraScript.enabled = true;
            	break;// Enable weird camera plus sounds
            case GameStage.GS_SCHOOL2: 
                school2bg.SetActive(true);
                break;
            case GameStage.GS_BADEND:
                badEndFadeout.SetActive(true);
                break;
            default:
            	break;
        }
    }
}