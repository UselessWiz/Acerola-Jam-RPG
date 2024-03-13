using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStage {
	GS_SCHOOL, //Includes the corridor part of the game
	GS_CASTLE, 
	GS_GRASSFIELD,
	GS_SCHOOL2,
	GS_GOODEND,
	GS_BADEND
}

public class SaveData : ScriptableObject {
	public int clockHours = 9;
	public int clockMinutes = 0;

	public GameStage stage;

	public void IncreaseTime()
	{
		clockMinutes += 5;

		if (clockMinutes == 60) {
			clockMinutes = 0;
			clockHours += 1;
		}

		if (clockHours == 24 && stage != GameStage.GS_GOODEND) {
			ChangeStage(GameStage.GS_BADEND);
		}
	}

	public void SetClock(int hours, int minutes)
	{
		clockHours = hours;
		clockMinutes = minutes;
	}

	public void ChangeStage(GameStage newStage) // This should be called by the triggers for switching GameStage.
	{
		stage = newStage;
		GameObject.Find("Player").GetComponent<ComponentController>().ChangeStage(stage);
	}
}