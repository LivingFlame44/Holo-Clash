using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "ASMR", menuName = "ScriptableObjects/Skills/ASMR")]
public class ASMR : Skill
{
    public override void Use(List<HoloMem> member)
    {
        foreach (HoloMem mem in member)
        {
            mem.hp = Mathf.Clamp(mem.hp + value, 0, mem.maxHP);
        }

        switch (member[0].team)
        {
            case HoloMem.Team.BLUE:
                CustomManager.p2Stamina = CustomManager.p2Stamina - cost;
                break;

            case HoloMem.Team.RED:
                CustomManager.p1Stamina = CustomManager.p1Stamina - cost;
                break;
        }
    }
}
