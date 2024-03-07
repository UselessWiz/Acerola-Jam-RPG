using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageChanger : MonoBehaviour
{
	[SerializeField] private GameStage thisStage;

	[SerializeField] private GameObject player;
	[SerializeField] private SaveData saveData;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player) {
			saveData.ChangeStage(thisStage);
			gameObject.SetActive(false);
		}
	}
}