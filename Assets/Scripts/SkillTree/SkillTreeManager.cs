using TMPro;
using UnityEngine;
//using TMPro;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
public class SkillTreeManager : MonoBehaviour
{
    public SkillSlot[] skillSlots;
    public TMP_Text pointsText;

    public int availablePoints;

    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointsSpent;
        SkillSlot.OnSkillMaxed += HanleSkillMaxed;
        ExpScripts.OnLevelUp += UpdateAbilityPoints;
    }

    private void OnDisable( ) 
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointsSpent;
        SkillSlot.OnSkillMaxed -= HanleSkillMaxed;
        ExpScripts.OnLevelUp -= UpdateAbilityPoints;    

    }

    private void HandleAbilityPointsSpent(SkillSlot skillSlot)
    {
        if(availablePoints>0)
        {
            UpdateAbilityPoints(-1);
        }

    }

    private void HanleSkillMaxed(SkillSlot skillSlot)
    {
        foreach(SkillSlot slot in skillSlots)
        {
            if(!slot.isUnlocked && slot.CanUnlockSkill())
            {
                slot.Unlock();
            }
            //slot.Unlock();
        }
    }



    private void Start()
    {
        foreach (SkillSlot slot in skillSlots) {
            slot.skillButton.onClick.AddListener(() => CheckAvaiablePoints(slot));
        
        }
        UpdateAbilityPoints(0);
    }

    private void CheckAvaiablePoints(SkillSlot slot)
    {
        if (availablePoints > 0)
        {
            slot.TryUpgradeSkill();
        }
    }

    public void UpdateAbilityPoints(int amount)
    {
        availablePoints += amount;
        pointsText.text = "Points: " + availablePoints;
    }
}
