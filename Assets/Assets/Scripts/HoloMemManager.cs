using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloMemManager : MonoBehaviour
{
    public HoloMem[] holoMems;
    private string folderPath = "HoloMem"; // Folder name inside the Assets/Resources folder

    void Awake()
    {
        holoMems = Resources.LoadAll<HoloMem>(folderPath);
    }
}
