using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSDHair : MonoBehaviour 
{
	// quickly shift between like 20 colors with an animatino that sets a bunch of colours. This is probably the easiest way, and it means i can make it a little trippy :)
	public void Update()
	{
		//Animator.Start("ColorShift");
	}

	public void OnDisable()
	{
		//Animator.Stopall? Might not even be needed actually.
	}
}