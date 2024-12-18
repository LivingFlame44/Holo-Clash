using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class MemInfoSelection : MonoBehaviour
{
    public HoloMemManager holoMemManager;
    public Transform parentPos;
    public GameObject holoMemButtonPrefab;
    public HoloMemInfoView holoMemInfoView;
    public GameObject iconsPanel;

    int panelSize;

    public void OnEnable()
    {
        holoMemInfoView.DisplayMemInfo(holoMemManager.holoMems[0]);
    }
    void Start()
    {
        foreach (HoloMem p in holoMemManager.holoMems)
        {
            GameObject buttonPrefab = Instantiate(holoMemButtonPrefab,parentPos);
            MemInfoBtn memInfoBtn = buttonPrefab.GetComponent<MemInfoBtn>();
            memInfoBtn.SetMemIcon(p);
            Button button = buttonPrefab.GetComponent<Button>();
            button.onClick.AddListener(() => holoMemInfoView.DisplayMemInfo(p));
        }

        panelSize = (holoMemManager.holoMems.Length * 75) + ((holoMemManager.holoMems.Length - 1) * 5);
        RectTransform rt = iconsPanel.GetComponent<RectTransform>();
        RectTransform rt2 = rt.GetComponent(typeof(RectTransform)) as RectTransform;
        rt2.sizeDelta = new Vector2(panelSize, 75);

        holoMemInfoView.DisplayMemInfo(holoMemManager.holoMems[0]);
    }

}
