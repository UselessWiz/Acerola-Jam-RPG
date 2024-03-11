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

    [SerializeField] private Animator animator;

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
            if (direction == Vector2.zero) stopped = true;
            stoppedFinished = Time.time;  
        }

        if (direction == Vector2.zero) {
            angle = oldAngle;
        }
        else {
            transform.Translate(Vector2.ClampMagnitude(direction, 1f) * speed * Time.deltaTime);

            direction = direction.normalized;

            if (stopped) {
                angle = 270;
                animator.Play("Idle");
            }
            else {
                angle = Mathf.Atan2(direction.y, direction.x) * 180/Mathf.PI;
                if (angle < 0) angle += 360;

                if (angle >= 45 && angle <= 135) animator.Play("Back");
                else if (angle > 135 && angle < 225) animator.Play("Left");
                else if (angle >= 225 && angle <= 335) animator.Play("Front");
                else animator.Play("Right");
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
            Debug.Log("student contacted");
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
