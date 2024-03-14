using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private GameStage currentStage;
    [SerializeField] private SaveData saveData;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> tracks;

    // Update is called once per frame
    void Update()
    {
        if (currentStage != saveData.stage) {
            currentStage = saveData.stage;
            if (currentStage == GameStage.GS_BADEND) {
                audioSource.Pause();
                return;
            }
            else if (currentStage == GameStage.GS_GOODEND) {
                audioSource.loop = false;
            }
            
            audioSource.clip = tracks[(int)currentStage];
            audioSource.Play();
        }
    }
}
