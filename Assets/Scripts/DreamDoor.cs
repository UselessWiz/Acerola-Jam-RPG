using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamDoor : MonoBehaviour
{
    [SerializeField] private SaveData saveData;
    // Update is called once per frame
    void Update()
    {
        if (saveData.clockHours == 11) {
            GetComponent<Collider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            this.enabled = false;
        }
    }
}
