using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Skill : ScriptableObject
{
    public string[] type;
    public string ssName;
    public string ssInfo;
    public Sprite ssPic;

    public int value;
    public int cost;
    
    public enum Target
    {
        SELF,
        ALLY,
        ALLIES,
        ENEMY,
        ENEMIES,
        MULTI
    }

    [SerializeField]
    [Flags]
    public enum SkillType
    {
        NONE = 0,
        HEAL = 1,
        DAMAGE = 2,
        BUFF = 4,
    }

    public virtual void Use(List<HoloMem> member)
    {
        
    }

    public void ApplyToButton()
    {

    }

    public Target target;
    public SkillType skillType;
}
