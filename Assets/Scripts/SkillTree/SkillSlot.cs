using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using NUnit.Framework;
using System.Collections.Generic;
public class SkillSlot : MonoBehaviour
{
    public SkillSO skillSO;
    public List<SkillSlot> prerequisiteSkillSLots;

    public int currentLevel;
    public bool isUnlocked;
    public TMP_Text skillLevelText;
    public Button skillButton;
    public Image skillIcon;

    public static event Action<SkillSlot> OnAbilityPointSpent;
    public static event Action<SkillSlot> OnSkillMaxed;
    private void OnValidate()
    {
        if(skillSO != null && skillLevelText!= null){
              
            UpdateUI();
        }
    }

    public void TryUpgradeSkill()
    {
        if(isUnlocked && currentLevel < skillSO.maxLevel)
        {
            currentLevel++;
            OnAbilityPointSpent?.Invoke(this);

            if (currentLevel >= skillSO.maxLevel)
            {
                OnSkillMaxed?.Invoke(this);
            }
            UpdateUI();

        }
    }

    public bool CanUnlockSkill()
    {
        foreach(SkillSlot item in prerequisiteSkillSLots)
        {
            if (!item.isUnlocked || item.currentLevel < item.skillSO.maxLevel )
            {
                return false;   
            }
        }


        return true;
    }

    public void Unlock()
    {
        isUnlocked = true;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (skillSO == null) Debug.LogError("skillSO is NULL", this);
        if (skillIcon == null) Debug.LogError("skillIcon is NULL", this);
        if (skillButton == null) Debug.LogError("skillButton is NULL", this);
        if (skillLevelText == null) Debug.LogError("skillLevelText is NULL", this);

        skillIcon.sprite = skillSO.skillIcon;
        if (isUnlocked)
        {
            skillButton.interactable = true;
            skillLevelText.text = currentLevel.ToString() + "/" + skillSO.maxLevel.ToString();
            skillLevelText.color = Color.black;
        }
        else
        {
            skillButton.interactable = false;
            skillLevelText.text = "Looker";
            skillLevelText.color = Color.gray;
        }
    }
}
