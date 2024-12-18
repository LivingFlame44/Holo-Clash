using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class SkillInfoSelection : MonoBehaviour
{
    public SkillManager skillManager;
    public Transform parentPos;
    public GameObject skillButtonPrefab;
    public SkillInfoView skillInfoView;

    public GameObject btnsPanel;
    public TMP_Dropdown skillTypeDropdown;
    int panelSize;

    public List<Skill> skillsDisplayed;

    public enum PanelState
    {
        ALL,
        DAMAGE,
        HEAL,
        BUFF,
    }

    public PanelState panelState;
    void Start()
    {
        panelState = PanelState.ALL;
        RemoveSkillButtons();
        foreach (Skill s in skillManager.skills)
        {
            GameObject buttonPrefab = Instantiate(skillButtonPrefab, parentPos);
            SkillInfoBtn skillInfoBtn = buttonPrefab.GetComponent<SkillInfoBtn>();
            skillInfoBtn.SetSkillBtnInfo(s);
            Button button = buttonPrefab.GetComponent<Button>();
            button.onClick.AddListener(() => skillInfoView.DisplaySkillInfo(s));
        }
        //foreach (HoloMem p in holoMemManager.holoMems)
        //{
        //    GameObject buttonPrefab = Instantiate(holoMemButtonPrefab, parentPos);
        //    MemInfoBtn memInfoBtn = buttonPrefab.GetComponent<MemInfoBtn>();
        //    memInfoBtn.SetMemIcon(p);
        //    Button button = buttonPrefab.GetComponent<Button>();
        //    button.onClick.AddListener(() => holoMemInfoView.DisplayMemInfo(p));
        //}


        //panelSize = (holoMemManager.holoMems.Length * 75) + ((holoMemManager.holoMems.Length - 1) * 5);
        //RectTransform rt = btnsPanel.GetComponent<RectTransform>();
        //RectTransform rt2 = rt.GetComponent(typeof(RectTransform)) as RectTransform;
        //rt2.sizeDelta = new Vector2(panelSize, 75);

        //holoMemInfoView.DisplayMemInfo(holoMemManager.holoMems[0]);
    }

    void Update()
    {
        //switch(panelState)
        //{
        //    case PanelState.ALL:
        //        RemoveSkillButtons();
        //        foreach (Skill s in skillManager.skills)
        //        {
        //            GameObject buttonPrefab = Instantiate(skillButtonPrefab, parentPos);
        //            SkillInfoBtn skillInfoBtn = buttonPrefab.GetComponent<SkillInfoBtn>();
        //            skillInfoBtn.SetSkillBtnInfo(s);
        //            Button button = buttonPrefab.GetComponent<Button>();
        //            button.onClick.AddListener(() => skillInfoView.DisplaySkillInfo(s));
        //        }

        //        break;

        //    case PanelState.DAMAGE:
        //        RemoveSkillButtons();
        //        foreach (Skill s in skillManager.skills)
        //        {
        //            if (s.skillType.HasFlag(Skill.SkillType.DAMAGE))
        //            {
        //                GameObject buttonPrefab = Instantiate(skillButtonPrefab, parentPos);
        //                SkillInfoBtn skillInfoBtn = buttonPrefab.GetComponent<SkillInfoBtn>();
        //                skillInfoBtn.SetSkillBtnInfo(s);
        //                Button button = buttonPrefab.GetComponent<Button>();
        //                button.onClick.AddListener(() => skillInfoView.DisplaySkillInfo(s));
        //            }                  
        //        }
        //        break;

        //    case PanelState.HEAL:
        //        RemoveSkillButtons();
        //        foreach (Skill s in skillManager.skills)
        //        {
        //            if (s.skillType.HasFlag(Skill.SkillType.HEAL))
        //            {
        //                GameObject buttonPrefab = Instantiate(skillButtonPrefab, parentPos);
        //                SkillInfoBtn skillInfoBtn = buttonPrefab.GetComponent<SkillInfoBtn>();
        //                skillInfoBtn.SetSkillBtnInfo(s);
        //                Button button = buttonPrefab.GetComponent<Button>();
        //                button.onClick.AddListener(() => skillInfoView.DisplaySkillInfo(s));
        //            }
        //        }
        //        break;

        //    case PanelState.BUFF:
        //        RemoveSkillButtons();
        //        break;

        //}
    }

    private void OnEnable()
    {
        RemoveSkillButtons();
        skillsDisplayed.Clear();
        foreach (Skill s in skillManager.skills)
        {
            GameObject buttonPrefab = Instantiate(skillButtonPrefab, parentPos);
            SkillInfoBtn skillInfoBtn = buttonPrefab.GetComponent<SkillInfoBtn>();
            skillInfoBtn.SetSkillBtnInfo(s);
            Button button = buttonPrefab.GetComponent<Button>();
            button.onClick.AddListener(() => skillInfoView.DisplaySkillInfo(s));
            skillsDisplayed.Add(s);
        }
        skillInfoView.DisplaySkillInfo(skillsDisplayed[0]);
    }

    private void OnDisable()
    {
        panelState = PanelState.ALL;
        RemoveSkillButtons();
        skillTypeDropdown.value = 0;
    }

    public void HandleInputData()
    {
        if (skillTypeDropdown.value == 0)
        {
            panelState = PanelState.ALL;
            RemoveSkillButtons();
            skillsDisplayed.Clear();
            foreach (Skill s in skillManager.skills)
            {
                GameObject buttonPrefab = Instantiate(skillButtonPrefab, parentPos);
                SkillInfoBtn skillInfoBtn = buttonPrefab.GetComponent<SkillInfoBtn>();
                skillInfoBtn.SetSkillBtnInfo(s);
                Button button = buttonPrefab.GetComponent<Button>();
                button.onClick.AddListener(() => skillInfoView.DisplaySkillInfo(s));
                skillsDisplayed.Add(s);
            }
            ChangePanelSize();
            skillInfoView.DisplaySkillInfo(skillsDisplayed[0]);
        }

        if (skillTypeDropdown.value == 1)
        {
            panelState = PanelState.DAMAGE;
            RemoveSkillButtons();
            skillsDisplayed.Clear();
            foreach (Skill s in skillManager.skills)
            {
                if (s.skillType.HasFlag(Skill.SkillType.DAMAGE))
                {
                    GameObject buttonPrefab = Instantiate(skillButtonPrefab, parentPos);
                    SkillInfoBtn skillInfoBtn = buttonPrefab.GetComponent<SkillInfoBtn>();
                    skillInfoBtn.SetSkillBtnInfo(s);
                    Button button = buttonPrefab.GetComponent<Button>();
                    button.onClick.AddListener(() => skillInfoView.DisplaySkillInfo(s));
                    skillsDisplayed.Add(s);
                }
            }
            ChangePanelSize();
            skillInfoView.DisplaySkillInfo(skillsDisplayed[0]);
        }
        if (skillTypeDropdown.value == 2)
        {
            panelState = PanelState.HEAL;
            RemoveSkillButtons();
            skillsDisplayed.Clear();
            foreach (Skill s in skillManager.skills)
            {
                if (s.skillType.HasFlag(Skill.SkillType.HEAL))
                {
                    GameObject buttonPrefab = Instantiate(skillButtonPrefab, parentPos);
                    SkillInfoBtn skillInfoBtn = buttonPrefab.GetComponent<SkillInfoBtn>();
                    skillInfoBtn.SetSkillBtnInfo(s);
                    Button button = buttonPrefab.GetComponent<Button>();
                    button.onClick.AddListener(() => skillInfoView.DisplaySkillInfo(s));
                    skillsDisplayed.Add(s);
                }
            }
            ChangePanelSize();
            skillInfoView.DisplaySkillInfo(skillsDisplayed[0]);
        }
        if (skillTypeDropdown.value == 3)
        {
            panelState = PanelState.BUFF;
        }
        else
        {
            panelState = PanelState.ALL;
        }
    }

    public void RemoveSkillButtons()
    {
        for (int i = btnsPanel.transform.childCount; i > 0; i--)
        {
            Object.Destroy(btnsPanel.transform.GetChild(i-1).gameObject);
        }
    }

    public void ChangePanelSize()
    {
        panelSize = 20 + (skillsDisplayed.Count%2 * 80) + (Mathf.Clamp(skillsDisplayed.Count / 2,1,1000) * 80);
        RectTransform rt = btnsPanel.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(600, panelSize);
    }
}
