using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "GamerMaid", menuName = "ScriptableObjects/Skills/GamerMaid")]
public class GamerMaid : Skill
{

    public override void Use(List<HoloMem> member)
    {
        member[0].hp = Mathf.Clamp(member[0].hp - value, 0, member[0].maxHP);

        switch (member[0].team)
        {
            case HoloMem.Team.RED:
                CustomManager.p2Stamina = CustomManager.p2Stamina - cost;
                break;

            case HoloMem.Team.BLUE:
                CustomManager.p1Stamina = CustomManager.p1Stamina - cost;
                break;
        }
    }
}
