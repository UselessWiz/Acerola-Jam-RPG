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

    public bool dialogueFinished;
    [SerializeField] private List<Student> queuedDialogue;
    [SerializeField] private Student currentStudent;

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
        // Movement
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

        // Dialogue
        if (queuedDialogue.Count > 0 && dialogueFinished) {
            StartCoroutine(dialogueBox.GetComponent<DialogueBox>().Display(queuedDialogue[0].GetDialogue(), queuedDialogue[0].delay));
            queuedDialogue.RemoveAt(0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Student") {
            Student student = other.GetComponent<Student>();
            if (dialogueFinished) {
                StartCoroutine(dialogueBox.GetComponent<DialogueBox>().Display(student.GetDialogue(), student.delay));
            }
            else {
                queuedDialogue.Add(student);
            }
        }
    }

    public void Stop(float time)
    {
        stopped = true;
        stoppedFinished = Time.time + time;
    }
}
