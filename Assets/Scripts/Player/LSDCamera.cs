using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSDCamera : MonoBehaviour 
{
	[SerializeField] private GameObject player;

	void Update()
	{
		transform.position = player.transform.position + new Vector3(0, Mathf.Sin(2 * Time.time), 0);
	}
}