using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HoloMemInfoView : MonoBehaviour
{
    public HoloMem holoMem;

    [Header("UI Headers")]

    public Image memPic;
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI hpTxt;
    public TextMeshProUGUI atkTxt;
    public TextMeshProUGUI spdTxt;

    public Image ssPic;
    public TextMeshProUGUI ssName;
    public TextMeshProUGUI ssInfo;
    public TextMeshProUGUI costTxt;
    public void OnEnable()
    {
        
    }
    public void DisplayMemInfo(HoloMem holoMem)
    {
        nameTxt.text = holoMem.name;
        hpTxt.text = "HP: " + holoMem.hp.ToString();
        atkTxt.text = "ATK: " + holoMem.atk.ToString();
        spdTxt.text = "SPD: " + holoMem.spd.ToString();
        memPic.sprite = holoMem.infoPic; 

        ssPic.sprite = holoMem.skills[1].ssPic;
        ssName.text = holoMem.skills[1].ssName;
        ssInfo.text = holoMem.skills[1].ssInfo;
        costTxt.text = "Stamina Cost: " + holoMem.skills[1].cost.ToString();
    }

    public void ClearView()
    {
        holoMem = null;
        nameTxt.text = null;
        hpTxt.text = null;
        atkTxt.text = null;
        spdTxt.text = null;
        memPic.sprite = null;
    }
    public void OnDisable()
    {
        ClearView();
    }
}
