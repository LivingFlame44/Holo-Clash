using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SkillInfoBtn : MonoBehaviour
{
    public Transform parentPos;
    public Image ssImg;
    public TextMeshProUGUI ssName;

    public GameObject skillTypePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSkillBtnInfo(Skill skill)
    {
        ssImg.sprite = skill.ssPic;
        ssName.text = skill.ssName;

        if (skill.skillType.HasFlag(Skill.SkillType.DAMAGE))
        {
            GameObject buttonPrefab0 = Instantiate(skillTypePrefab, parentPos);
            buttonPrefab0.GetComponentInChildren<TextMeshProUGUI>().text = "DAMAGE";
        }
        if (skill.skillType.HasFlag(Skill.SkillType.HEAL))
        {
            GameObject buttonPrefab1 = Instantiate(skillTypePrefab, parentPos);
            buttonPrefab1.GetComponentInChildren<TextMeshProUGUI>().text = "HEAL";
        }
        if (skill.skillType.HasFlag(Skill.SkillType.BUFF))
        {
            GameObject buttonPrefab2 = Instantiate(skillTypePrefab, parentPos);
            buttonPrefab2.GetComponentInChildren<TextMeshProUGUI>().text = "BUFF";
        }
    }

}
