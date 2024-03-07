using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSDCamera : MonoBehaviour 
{
	[SerializeField] private MovementController playerMovement;
	[SerializeField] private float verticalVelocity;
	[SerializeField] private float gravity = -10;

	void Update()
	{
		verticalVelocity += gravity * Time.deltaTime;
		transform.Translate(Vector2.down * verticalVelocity * Time.deltaTime);

		if (transform.position.y < -1 && playerMovement.direction != Vector2.zero) {
			verticalVelocity = 12;
		}
		else {
			verticalVelocity = 0;
		}
	}
}