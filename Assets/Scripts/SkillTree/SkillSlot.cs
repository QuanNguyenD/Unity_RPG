using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSlot : MonoBehaviour
{
    public SkillSO skillSO;

    public int currentLevel;
    public bool isUnlocked;
    public TMP_Text skillLevelText;
    public Button skillButton;
    public Image skillIcon;

    private void OnValidate()
    {
        if(skillSO != null && skillLevelText!= null){
              
            UpdateUI();
        }
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
