using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour {
    public int[] anagorev;
    public Text atesleyici, aku, teker, yakit,gorev_text;
    public SceneSaveVariables m_savevariables;
    public FlashlightController m_flashlightcont;
    public GameObject itemtake,pause_menu,hand;
    public bool flashlight_onoff,pause;
    public AudioSource m_audiosource;
    [SerializeField] private AudioClip[] m_audioclips;
    void Start () {
 
          
        Debug.Log("PlayerControl çalıştırıldı");
        m_audiosource = GetComponent<AudioSource>();
        m_savevariables = GameObject.FindGameObjectWithTag("SaveLoad").GetComponent<SceneSaveVariables>();
        anagorev[0] = PlayerPrefs.GetInt("atesleyici_anagorev");
        anagorev[1] = PlayerPrefs.GetInt("aku_anagorev");
        anagorev[2] = PlayerPrefs.GetInt("teker_anagorev");
        anagorev[3] = PlayerPrefs.GetInt("yakit_anagorev");
        atesleyici.text = anagorev[0] + "/1";
        aku.text = anagorev[1] + "/1";
        teker.text = anagorev[2] + "/4";
        yakit.text = anagorev[3] + "/2";
    }
    private void OnLevelWasLoaded(int level)
    {
        Start();
    }
    void Update()
    {

        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 6))
        {
            var selection = hit.transform;
            Debug.DrawLine(ray.origin, hit.point);
            if (selection.CompareTag("item"))
            {
                itemtake.GetComponent<Text>().text = (selection.name).ToUpper() + " Öğesini Al. (F tuşuna bas.)";
                if (Input.GetKeyDown(KeyCode.F))
                {

                    if (selection.name == "pil")
                    {
                        m_flashlightcont.pil_deger += 5;
                    }

                    if (selection.name == "ateşleyici")
                    {
                        anagorev[0]++;
                        PlayerPrefs.SetInt("atesleyici_anagorev", anagorev[0]);
                        atesleyici.text = anagorev[0] + "/1";
                    }
                    if (selection.name == "akü")
                    {
                        anagorev[1]++;
                        PlayerPrefs.SetInt("aku_anagorev", anagorev[1]);
                        aku.text = anagorev[1] + "/1";
                    }
                    if (selection.name == "teker1" || selection.name == "teker2" || selection.name == "teker3" || selection.name == "teker4")
                    {
                        anagorev[2]++;
                        PlayerPrefs.SetInt("teker_anagorev", anagorev[2]);
                        teker.text = anagorev[2] + "/4";
                    }
                    if (selection.name == "yakit1" || selection.name == "yakit2")
                    {
                        anagorev[3]++;
                        PlayerPrefs.SetInt("yakit_anagorev", anagorev[3]);
                        yakit.text = anagorev[3] + "/2";
                    }
                    Destroy(selection.gameObject);
                    PlayerPrefs.SetInt(selection.name, 1);
                    m_audiosource.PlayOneShot(m_audioclips[2]);
                    missioncontrol();
                }
            }
            else if (selection.CompareTag("fener"))
            {
                itemtake.GetComponent<Text>().text = (selection.name).ToUpper() + " Öğesini Al. (F tuşuna bas.)";
                if (Input.GetKeyDown(KeyCode.F))
                {
                    hand.SetActive(true);

                    PlayerPrefs.SetInt("s_fener", 1);
                    PlayerPrefs.SetInt(selection.name + "s_esya", 1);
                    PlayerPrefs.SetString("s_objective", "esyalaribul");
                    Destroy(selection.gameObject);
                    Objectivechange("Görev : Aracı tamir etmek için gerekli olan parçaları bul ve kasabadan kaç.");
                    m_audiosource.PlayOneShot(m_audioclips[2]);
                }
            }
            else if (selection.CompareTag("kapi"))
            {
                itemtake.GetComponent<Text>().text = (selection.gameObject.GetComponent<scenetriggerchange>().scenetextname) + "(F tuşuna bas.)";
                if (Input.GetKeyDown(KeyCode.F))
                {
                    m_savevariables.scenevarsave();
                    m_audiosource.PlayOneShot(m_audioclips[3]);
                    SceneManager.LoadScene(selection.gameObject.GetComponent<scenetriggerchange>().sceneindexname);
                }
            }
            else if (selection.CompareTag("arac"))
            {
                if (anagorev[0] >= 1 && anagorev[1] >= 1 && anagorev[2] >= 4 && anagorev[3] >= 2)
                {
                    itemtake.GetComponent<Text>().text = ("Parçaları araca yerleştirmek için (F tuşuna bas.)");
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        m_audiosource.PlayOneShot(m_audioclips[5]);
                        SceneManager.LoadScene("finalscene");
                    }
                }
                else
                {
                    itemtake.GetComponent<Text>().text = ("Aracı tamir etmek için parçaların hepsini bulmalısın.");
                }
            }
            else
            {
                itemtake.GetComponent<Text>().text = "";
            }


            if (Input.GetButtonDown("Fire1"))
            {
                if (hand.activeSelf == true)
                {
                    flashlight_onoff = !flashlight_onoff;
                    m_audiosource.PlayOneShot(m_audioclips[0]);
                }

            }
            if (Input.GetKeyDown(KeyCode.P))
            {

                m_audiosource.PlayOneShot(m_audioclips[1]);
                pause = !pause;

                if (pause == true)
                {
                    pause_menu.SetActive(true);
                    Time.timeScale = 0.0f;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
                    AudioListener.volume = 0;
                }
                if (pause == false)
                {
                    pause_menu.SetActive(false);
                    Time.timeScale = 1f;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
                    AudioListener.volume = 1;
                }

            }
        }
    }
    void Objectivechange(string objective_Text)
    {
        StartCoroutine("newmission", objective_Text);
    }
    IEnumerator newmission(string objective_Text)
    {
        gorev_text.gameObject.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2f);
        m_audiosource.PlayOneShot(m_audioclips[4]);
        gorev_text.text = objective_Text;
        yield return new WaitForSeconds(2f);
        gorev_text.gameObject.GetComponent<Animator>().enabled = false;
    }
    void missioncontrol()
    {
        if (anagorev[0] >= 1 && anagorev[1] >= 1 && anagorev[2] >= 4 && anagorev[3] >= 2)
        {
            PlayerPrefs.SetString("s_objective","kasabadankac");
            Objectivechange("Görev: Topladığın parçaları araca yerleştir ve kasabadan kaç.");
        }
    }
    void ItemControl(string itemname)
    {
        
        switch(itemname)
        {
            case "fener":
                Debug.Log(itemname + "alındı");
                break;
            case "pil":
               
                Debug.Log(itemname + "alındı");
                break;
            case "yakıt":
      
                Debug.Log(itemname + "alındı");
                break;
            case "teker":
              Debug.Log(itemname + "alındı");
                break;
            case "akü":
                Debug.Log(itemname + "alındı");
                break;
            case "ateşleyici":
                Debug.Log(itemname + "alındı");
                break;
        }
        
    }
    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void APPquit()
    {
        Application.Quit();
    }
}
    

