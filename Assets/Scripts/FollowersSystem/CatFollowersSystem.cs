using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;


public class CatFollowersSystem : MonoBehaviour
{
    public static  Action onNewFollowers;
    public static Action onFollowersRequest;
    public static  Action onDisconnect;
    public static  Action onFollowersHelp;

    public static CatFollowersSystem instance;
    


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



}
