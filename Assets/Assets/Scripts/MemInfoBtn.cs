using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class MemInfoBtn : MonoBehaviour
{
    public Image memIcon;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMemIcon(HoloMem unit)
    {
       memIcon.sprite = unit.btnPic;
    }
}
