using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpen;
    }

    private void OnDisEnable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpen;
    }


    private void HandleAbilityPointSpen(SkillSlot slot)
    {
        string skillName = slot.skillSO.skillName;

        switch (skillName) 
        {
            case "Max Health Boost":
                StatsManagerment.Instance.UpdateMaxHealth(1);
                break;

            case "DEF UP":
                StatsManagerment.Instance.UpdateDef(1);
                break;
            case "ATK UP":
                StatsManagerment.Instance.UpdateMaxATK(1);
                break;

            default:
                Debug.LogWarning("Unknown skill: " + skillName);
                break;




        }

    }


}
