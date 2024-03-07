using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float oldAngle;
    [SerializeField] private bool stopped = false;
    [SerializeField] private float stoppedFinished;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private SaveData saveData;

    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0, 0, 0); 
        saveData.ChangeStage(GameStage.GS_SCHOOL);
    }

    // Update is called once per frame
    void Update()
    {
        float angle = 0;

        if (stopped) {
            direction = Vector2.zero;
            if (Time.time > stoppedFinished) stopped = false;
        }
        else {
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));    
        }

        if (direction == Vector2.zero) {
            angle = oldAngle;
        }
        else {
            // Move
            transform.Translate(Vector2.ClampMagnitude(direction, 1f) * speed * Time.deltaTime);

            direction = direction.normalized;

            if (direction == Vector2.zero) {
                angle = 270;
            }
            else {
                angle = Mathf.Atan2(direction.y, direction.x) * 180/Mathf.PI;
                if (angle < 0) angle += 360;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Student") {
            StartCoroutine(dialogueBox.GetComponent<DialogueBox>().Display(other.GetComponent<Student>().GetDialogue(), 5f));
        }
    }

    public void Stop(float time)
    {
        stopped = true;
        stoppedFinished = Time.time + time;
    }
}
