using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;
public class CustomManager : MonoBehaviour
{
    public static int p1Stamina = 4;
    public static int p2Stamina = 4;

    public int p1AlivePlayers = 3;
    public int p2AlivePlayers = 3;
    public CustomCharDisplay customCharDisplay;
    public HoloMemManager holoMemManager;

    public List<HoloMem> holoTurnOrder;
    public List<int> turnOrder;


    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic("Tenkyu");
        p1Stamina = 4;
        p2Stamina = 4;
        turnOrder = new List<int> { 0, 1, 2, 3, 4, 5 };
        for (int i = 0; i < 3; i++)
        {
  
        }
        BubbleSort(turnOrder);
        customCharDisplay.DisplayTurnOrder(turnOrder);

        DisplayAllChar();
        AssignOrder(turnOrder);
    }

    public void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (p1AlivePlayers == 0)
        {
            Time.timeScale = 0;
            customCharDisplay.winPanel.SetActive(true);
            customCharDisplay.winPlayerTxt.text = "P2 WINS";
            customCharDisplay.winPlayerTxt.color = UnityEngine.Color.blue;
        }
        if(p2AlivePlayers == 0)
        {
            Time.timeScale = 0;
            customCharDisplay.winPanel.SetActive(true);
            customCharDisplay.winPlayerTxt.text = "P1 WINS";
            customCharDisplay.winPlayerTxt.color = UnityEngine.Color.red;
        }
    }

    public void DisplayAllChar()
    {
        for (int i = 0; i < 3; i++)
        {
            customCharDisplay.DisplayP1Character(CharSelectionManager.customTeam1[i], i);
            customCharDisplay.DisplayP2Character(CharSelectionManager.customTeam2[i], i);
        }
    }

    public void BubbleSort(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            for (int j = 0; j < numbers.Count - i - 1; j++)
            {
                //checks if p2 and p2
                if (numbers[j] > 2 && numbers[j + 1] > 2)
                {
                    if (CharSelectionManager.customTeam2[numbers[j]-3].spd < CharSelectionManager.customTeam2[numbers[j + 1]-3].spd)
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
                //check if p1 and p1
                if (numbers[j] < 3 && numbers[j + 1] < 3)
                {
                    if (CharSelectionManager.customTeam1[numbers[j]].spd < CharSelectionManager.customTeam1[numbers[j + 1]].spd)
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
                //checks if p1 and p2
                if (numbers[j] < 3 && numbers[j + 1] > 2)
                {
                    if (CharSelectionManager.customTeam1[numbers[j]].spd < CharSelectionManager.customTeam2[numbers[j + 1]-3].spd)
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
                //check if p2 and p1
                if (numbers[j] > 2 && numbers[j + 1] < 3)
                {
                    if (CharSelectionManager.customTeam2[numbers[j] - 3].spd < CharSelectionManager.customTeam1[numbers[j + 1]].spd)
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
        }
    }

    public void AssignOrder(List<int> list)
    {
        foreach(int i in turnOrder)
        {
            int ctr = 0;
            if (i < 3)
            {
                holoTurnOrder.Add(CharSelectionManager.customTeam1[i]);
           
            }
            else
            {
                holoTurnOrder.Add(CharSelectionManager.customTeam2[i-3]);
            }
            ctr = ctr + 1;
        }
    }

    public HoloMem WhichMember(int i)
    {
        HoloMem temp;
        switch (i)
        {
            case 0: temp = CharSelectionManager.customTeam1[i]; break;

            case 1: temp = CharSelectionManager.customTeam1[i]; break;

            case 2: temp = CharSelectionManager.customTeam1[i]; break;

            case 3: temp = CharSelectionManager.customTeam1[i-3]; break;

            case 4: temp = CharSelectionManager.customTeam1[i-3]; break;

            default: return CharSelectionManager.customTeam2[i-3];
        }
        return temp;
    }

    public void ChangeTurn()
    {
        int temp;
        temp = turnOrder[0];
        turnOrder.RemoveAt(0);
        turnOrder.Add(temp);

        HoloMem temporary;
        temporary = holoTurnOrder[0];
        holoTurnOrder.RemoveAt(0);
        holoTurnOrder.Add(temporary);
    }
}


