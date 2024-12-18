using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Skill[] skills;

    private string folderPath = "Skill";
  // Folder name inside the Assets/Resources folder

    void Awake()
    {
        skills = Resources.LoadAll<Skill>(folderPath);
    }
}