using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemcontrol : MonoBehaviour {
    private void OnLevelWasLoaded(int level)
    {
        if(PlayerPrefs.GetInt(gameObject.name) == 1)
        {
            Destroy(gameObject);
        }
    }
}
