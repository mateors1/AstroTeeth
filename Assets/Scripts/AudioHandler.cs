using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioListener))]
[RequireComponent(typeof(AudioSource))]
public class AudioHandler : MonoBehaviour
{
    GameControllerActions gameController;
    
    AudioSource sfxPlayer;
    
    [SerializeField]
    AudioClip jump;

    [SerializeField]
    AudioClip landing;

    [SerializeField]
    AudioClip lazer;

    [SerializeField]
    AudioClip ded;


    void Awake()
    {
        gameController = new GameControllerActions();
        gameController.Player.Jump.performed += ctx => JumpSFX();
        CatFollowersSystem.onDisconnect += IDied;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void JumpSFX()
    {
        if (jump != null)
        {
            sfxPlayer.PlayOneShot(jump);
        }
        else
        {
            Debug.Log("Jumped but no sound produced");
        }
       
    }
    // Update is called once per frame
    void IDied()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in allAudioSources)
        {
            source.gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        CatFollowersSystem.onDisconnect -= IDied;
    }
}
