using UnityEngine;

public class ToggleSkillTree : MonoBehaviour
{
    public CanvasGroup stastCanvas;
    private bool skillTreeOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ToggleStatsTree"))
        {
            if (skillTreeOpen)
            {
                Time.timeScale = 1;
                stastCanvas.alpha = 0;
                stastCanvas.blocksRaycasts = false; 
                skillTreeOpen = false;
            
            }
            else
            {
                Time.timeScale = 0;
                stastCanvas.alpha = 1;
                stastCanvas.blocksRaycasts = true;
                skillTreeOpen = true;
            }

        }
    }
}
