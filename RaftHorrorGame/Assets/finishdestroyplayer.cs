using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishdestroyplayer : MonoBehaviour {

    private void OnLevelWasLoaded(int level)
    {
        Destroy(GameObject.FindGameObjectWithTag("PlayerMother"));
    }
    void Start () {
        Destroy(GameObject.FindGameObjectWithTag("PlayerMother"));
	}
	

}
