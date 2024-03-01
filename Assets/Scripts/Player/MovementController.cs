using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private GameObject dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Move
        transform.Translate(Vector2.ClampMagnitude(direction, 1f) * speed * Time.deltaTime);

        direction = direction.normalized;
        float angle = 0;
        if (direction == Vector2.zero) {
            angle = 270;
        }
        else {
            angle = Mathf.Atan2(direction.y, direction.x) * 180/Mathf.PI;
            if (angle < 0) angle += 360;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Student") {
            Debug.Log("THIS");
            StartCoroutine(dialogueBox.GetComponent<DialogueBox>().Display(other.GetComponent<Student>().GetDialogue(), 5f));
        }
    }
}
