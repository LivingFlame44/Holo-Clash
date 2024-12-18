using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SkillInfoView : MonoBehaviour
{
    public Image ssPic;
    public TextMeshProUGUI ssName;
    public TextMeshProUGUI ssInfo;
    public TextMeshProUGUI costTxt;

    public void OnEnable()
    {

    }
    public void DisplaySkillInfo(Skill skill)
    {
 
        ssPic.sprite = skill.ssPic;
        ssName.text = skill.ssName;
        ssInfo.text = skill.ssInfo;
        costTxt.text = "Stamina Cost: " + skill.cost.ToString();
    }

    public void ClearView()
    {

    }
    public void OnDisable()
    {
        ClearView();
    }
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
