using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecialSkills", menuName = "ScriptableObjects/SpecialSkills")]
public class SpecialSkill : ScriptableObject
{
    [SerializeField] string ssName;
    [SerializeField] string ssInfo;
    [SerializeField] Sprite ssPic;
}
