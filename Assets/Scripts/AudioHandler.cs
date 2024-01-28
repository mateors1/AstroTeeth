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

    void OnEnable()
    {
        gameController.Enable();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        sfxPlayer = GetComponent<AudioSource>();
    }

    public void JumpSFX()
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
        sfxPlayer.PlayOneShot(ded);
    }

    void OnDisable()
    {
        CatFollowersSystem.onDisconnect -= IDied;
    }
}
