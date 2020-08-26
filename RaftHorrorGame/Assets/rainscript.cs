using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainscript : MonoBehaviour {

    GameObject m_player;
	void Start () {
        m_player = GameObject.FindGameObjectWithTag("Player");	
	}
	
	void Update () {
        transform.position = new Vector3(m_player.transform.position.x, m_player.transform.position.y+5, m_player.transform.position.z);
	}
}
