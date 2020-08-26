using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyPlayer : MonoBehaviour {
    private static GameObject playerInstance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (playerInstance == null)
        {
            playerInstance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

    }
 
 }
