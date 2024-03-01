using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SaveData : ScriptableObject {
	public int clockHours = 9;
	public int clockMinutes = 0;

	public void IncreaseTime()
	{
		clockMinutes += 5;

		if (clockMinutes == 60) {
			clockMinutes = 0;
			clockHours += 1;
		}

		if (clockHours == 24) {
			Debug.Log("GAME OVER BAD ENDING");
		}
	}

	public void SetClock(int hours, int minutes)
	{
		clockHours = hours;
		clockMinutes = minutes;
	}
}