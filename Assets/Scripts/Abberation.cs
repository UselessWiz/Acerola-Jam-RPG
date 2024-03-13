using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abberation : MonoBehaviour
{
    public Vector2 movementTarget;
    public Vector2 bounds;

    [SerializeField] private float speed;
    [SerializeField] private float moveTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        bounds = new Vector2(transform.position.x + 10f, transform.position.y + 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTimer < Time.time) {
            movementTarget = new Vector2(UnityEngine.Random.Range(-bounds.x, bounds.x), UnityEngine.Random.Range(-bounds.y, bounds.y));
            moveTimer = Time.time + 10f;
        }

        if (transform.position == (Vector3)movementTarget) return;
        else if (((Vector3)movementTarget - transform.position).magnitude < 0.2) transform.position = (Vector3)movementTarget;

        transform.Translate(((Vector3)movementTarget - transform.position).normalized * speed * Time.deltaTime);
    }
}
