using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Gyudon", menuName = "ScriptableObjects/Skills/Gyudon")]
public class Gyudon : Skill
{
    public override void Use(List<HoloMem> member)
    {
        member[0].hp = Mathf.Clamp(member[0].hp + value, 0, member[0].maxHP);

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
