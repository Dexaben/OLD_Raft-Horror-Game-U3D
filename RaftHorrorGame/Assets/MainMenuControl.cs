using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuControl : MonoBehaviour {
    Animator m_animator;
    private void Start()
    {
        Destroy(GameObject.FindGameObjectWithTag("PlayerMother"));
        Time.timeScale = 1;
        m_animator = GetComponent<Animator>();
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("s_quality"));
    }
    public void SceneChange(string scenename)
    {
        if (scenename == "girisanim")
            PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(scenename);
      
            
    }
    public void animator(string animname)
    {
        m_animator.SetTrigger(animname);
    }
    public void applicationquit()
    {
        Application.Quit();
    }
    public void setqualitylevel(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
        PlayerPrefs.SetInt("s_quality", qualityindex);
    }
}
