using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetButtons : MonoBehaviour
{
    public int targetBtnID;
    public CustomCharDisplay customCharDisplay;
    public int targetPlayerNum;
    public enum Team
    {
        RED, BLUE
    }

    public Team team;
    // Start is called before the first frame update
    void Start()
    {
        customCharDisplay = GameObject.Find("HUD").GetComponent<CustomCharDisplay>();
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTarget()
    {
        
        if(customCharDisplay.currentTargetID == targetBtnID)
        {
            
        }

        else
        {
            customCharDisplay.currentTargetID = targetBtnID;
            
            foreach (GameObject i in customCharDisplay.targetCursor)
            {
                i.SetActive(false);
                
            }

            foreach (Button i in customCharDisplay.targetConfirmBtns)
            {
                i.gameObject.SetActive(false);
            }

            customCharDisplay.targetConfirmBtns[targetBtnID].gameObject.SetActive(true);
            customCharDisplay.targetCursor[targetBtnID].SetActive(true);
        }

        customCharDisplay.targetList.Clear();

        switch (team)
        {
            case Team.RED:
                switch (targetPlayerNum)
                {
                    case 0: customCharDisplay.targetList.Add(CharSelectionManager.customTeam1[targetPlayerNum]); break;

                    case 1: customCharDisplay.targetList.Add(CharSelectionManager.customTeam1[targetPlayerNum]); break;

                    case 2: customCharDisplay.targetList.Add(CharSelectionManager.customTeam1[targetPlayerNum]); break;
                }
                break;

            case Team.BLUE:
                switch (targetPlayerNum)
                {
                    case 0: customCharDisplay.targetList.Add(CharSelectionManager.customTeam2[targetPlayerNum]); break;

                    case 1: customCharDisplay.targetList.Add(CharSelectionManager.customTeam2[targetPlayerNum]); break;

                    case 2: customCharDisplay.targetList.Add(CharSelectionManager.customTeam2[targetPlayerNum]); break;
                }
                break;
        }
    }
}
