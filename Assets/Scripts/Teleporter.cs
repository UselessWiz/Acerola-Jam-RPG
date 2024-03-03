using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private GameObject otherTP;
    [SerializeField] private GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject == player) {
            player.transform.position = otherTP.transform.position + new Vector3(0, -2, 0);
        }
    }
}
