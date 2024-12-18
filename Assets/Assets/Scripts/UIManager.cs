using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    public GameObject mainMenuPanel;
    public GameObject teamMenuPanel;
    public GameObject teamCreatePanel;
    public GameObject memberInfoPanel;
    public GameObject skillInfoPanel;
    public GameObject welcomeMenuPanel;
    public GameObject createTeamMenuPanel;
    public GameObject guidePanel;

    public GameObject modeSelectionPanel;
    public GameObject customSelectionPanel;

    public GameObject settingsPanel;

    public GameObject firstTimePanel;
    // Start is called before the first frame update
    void Start()
    {

        if(PlayerPrefs.GetInt("FirstTime",0) == 0)
        {
            firstTimePanel.SetActive(true);
        }
        
        settingsPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void OpenMainMenu() 
    {
        mainMenuPanel.SetActive(true);
        welcomeMenuPanel.SetActive(false);
    }

    public void OpenTeamMenu()
    {
        teamMenuPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
    public void OpenMemberInfo() 
    {
        memberInfoPanel.SetActive(true);
        skillInfoPanel.SetActive(false);
        teamCreatePanel.SetActive(false);
    }

    public void OpenSkillInfo() 
    {
        teamCreatePanel.SetActive(false);
        skillInfoPanel.SetActive(true);
        memberInfoPanel.SetActive(false);
    }

    public void OpenCreateTeamPanel()
    {
        teamCreatePanel.SetActive(true);
        skillInfoPanel.SetActive(false);
        memberInfoPanel.SetActive(false);
    }

    public void OpenCustomSelection()
    {
        customSelectionPanel.SetActive(true);
        modeSelectionPanel.SetActive(false);
    }

    public void OpenModeSelect()
    {
        modeSelectionPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void OpenGuidePanel()
    {
        PlayerPrefs.SetInt("FirstTime", 1);
        guidePanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        firstTimePanel.SetActive(false);  
    }

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }
}
