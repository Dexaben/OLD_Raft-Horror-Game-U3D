using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSaveVariables : MonoBehaviour {
    public Transform spawnpoint;
    public GameObject m_Player,hand,yerdekifener;
    public PlayerControl m_PlayerControl;
    public Text atesleyici, aku, teker, yakit;
    public string[] alinanesyalar;
	void Start () {
        Debug.Log("SceneSaveVariables çalıştırıldı");
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_PlayerControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerControl>();
        if (GameObject.Find("spawnpoint") !=null)
        {
            spawnpoint = GameObject.Find("spawnpoint").transform;
        }
        if(GameObject.Find("fener") != null)
        {
            yerdekifener = GameObject.Find("fener");
        }
        //playertransform change
        if(spawnpoint != null)
        {
            m_Player.transform.position = spawnpoint.transform.position;
            m_Player.transform.rotation = spawnpoint.transform.rotation;
        }
        Debug.Log("SAVE LOADED");
        scenevarload();
        
	}
    private void OnLevelWasLoaded(int level)
    {
        Start();
    }
    public void scenevarsave()
    {
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "PlayerX", m_Player.transform.position.x);
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "PlayerY", m_Player.transform.position.y);
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "PlayerZ", m_Player.transform.position.z);
    }
    public void scenevarload()
    {

        if (PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "PlayerX",0) != 0)
        {
            m_Player.transform.position = new Vector3(PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "PlayerX"), PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "PlayerY"), PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "PlayerZ"));
        }
        if(PlayerPrefs.GetInt("s_fener") == 1)
        {
            hand.SetActive(true);
            yerdekifener.SetActive(false);
        }
        else
        {
            hand.SetActive(false);
            yerdekifener.SetActive(true);
        }
        switch(PlayerPrefs.GetString("s_objective"))
        {
            case "esyalaribul":
                m_PlayerControl.gorev_text.text = "Görev : Aracı tamir etmek için gerekli olan parçaları bul ve kasabadan kaç.";
                break;
            case "kasabadankac":
                m_PlayerControl.gorev_text.text = "Görev: Topladığın parçaları araca yerleştir ve kasabadan kaç.";
                break;
        }
        atesleyici.text = (PlayerPrefs.GetInt("atesleyici_anagorev") + "/1");
        aku.text = (PlayerPrefs.GetInt("aku_anagorev") + "/1");
        teker.text = (PlayerPrefs.GetInt("teker_anagorev") + "/4");
        yakit.text = (PlayerPrefs.GetInt("yakit_anagorev") + "/2");
    }
}
