using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CustomCharDisplay : MonoBehaviour
{
    public CustomManager customManager;

    public HoloMem holoMem;

    public GameObject[] p1Team;
    public GameObject[] p2Team;

    public GameObject[] allChar;

    public GameObject[] turnOrderPic;
    public Button[] skillBtns;
    public Button[] targetBtns;
    public Button[] targetConfirmBtns;
    public GameObject[] targetCursor;
    public GameObject currentMemName;

    public List<HoloMem> targetList;

    public TextMeshProUGUI staminaTxt;
    public GameObject actionPanel;
    public TextMeshProUGUI actionTxt;

    public GameObject winPanel;
    public TextMeshProUGUI winPlayerTxt;

    public bool targetSelected = false;
    public int currentTargetID = 6;
    // Start is called before the first frame update
    void Start()
    {
        customManager = GameObject.Find("CustomManager").GetComponent<CustomManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayP1Character(HoloMem holoMem, int p1CharNum)
    {
        p1Team[p1CharNum].GetComponentInChildren<TextMeshProUGUI>().text = holoMem.hp.ToString();
        p1Team[p1CharNum].GetComponent<Image>().sprite = holoMem.infoPic;
        p1Team[p1CharNum].GetComponentInChildren<Slider>().maxValue = holoMem.hp;
        p1Team[p1CharNum].GetComponentInChildren<Slider>().value = holoMem.hp;
    }

    public void DisplayP2Character(HoloMem holoMem, int p2CharNum)
    {
        p2Team[p2CharNum].GetComponentInChildren<TextMeshProUGUI>().text = holoMem.hp.ToString();
        p2Team[p2CharNum].GetComponent<Image>().sprite = holoMem.infoPic;
        p2Team[p2CharNum].GetComponentInChildren<Slider>().maxValue = holoMem.hp;
        p2Team[p2CharNum].GetComponentInChildren<Slider>().value = holoMem.hp;
    }

    public void DisplayUpdatedChar()
    {
        for (int i = 0; i < 3; i++)
        {
            p1Team[i].transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = CharSelectionManager.customTeam1[i].hp.ToString();
            p1Team[i].GetComponentInChildren<Slider>().value = CharSelectionManager.customTeam1[i].hp;

            p2Team[i].transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = CharSelectionManager.customTeam2[i].hp.ToString();
            p2Team[i].GetComponentInChildren<Slider>().value = CharSelectionManager.customTeam2[i].hp;
        }
    }

    public void P1ClearView(int p1CharNum)
    {
        p1Team[p1CharNum].GetComponentInChildren<TextMeshProUGUI>().text = null;
        p1Team[p1CharNum].GetComponent<Image>().sprite = null;
    }
    public void P2ClearView(int p2CharNum)
    {
        p2Team[p2CharNum].GetComponentInChildren<TextMeshProUGUI>().text = null;
        p2Team[p2CharNum].GetComponent<Image>().sprite = null;
    }

    public void DisplayTurnOrder(List<int> list)
    {
        int ctr = 0;
        foreach (int i in list)
        {
            if (i < 3)
            {
                turnOrderPic[ctr].gameObject.transform.GetChild(0).GetComponentInChildren<Image>().sprite = CharSelectionManager.customTeam1[i].btnPic;
                turnOrderPic[ctr].GetComponent<Image>().color = UnityEngine.Color.red;
            }
            else
            {
                turnOrderPic[ctr].gameObject.transform.GetChild(0).GetComponentInChildren<Image>().sprite = CharSelectionManager.customTeam2[i-3].btnPic;
                turnOrderPic[ctr].GetComponent<Image>().color = UnityEngine.Color.blue;
            }
            ctr = ctr + 1;
        }
    }

    public void DisplayCurrentMemberInfo(HoloMem member)
    {
        currentMemName.GetComponent<TextMeshProUGUI>().text = member.name + "'s Turn";
        switch (member.team)
        {
            case HoloMem.Team.RED:
                currentMemName.GetComponent<TextMeshProUGUI>().color = UnityEngine.Color.red;
                break;

            case HoloMem.Team.BLUE:
                currentMemName.GetComponent<TextMeshProUGUI>().color = UnityEngine.Color.blue;
                break;
        }
   
        DisplayTurnOrder(customManager.turnOrder);
        UpdateStamina();
        //Displays Current Chaarcter's turn's info
        int ctr = 0;
        
        foreach (Skill s in member.skills)
        {
            skillBtns[ctr].GetComponentInChildren<TextMeshProUGUI>().text = s.ssName;
            skillBtns[ctr].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Stamina Cost: " + s.cost;
            skillBtns[ctr].onClick.AddListener(() => AssignToTarget(s));

            switch ((customManager.holoTurnOrder[0].team))
            {
                case HoloMem.Team.RED:
                    if (CustomManager.p1Stamina < s.cost)
                    {
                        skillBtns[ctr].enabled = false;
                    }
                    else
                    {
                        skillBtns[ctr].enabled = true;
                    }
                    break;

                case HoloMem.Team.BLUE:
   
                    if (CustomManager.p2Stamina < s.cost)
                    {
                        skillBtns[ctr].enabled = false;
                    }
                    else
                    {
                        skillBtns[ctr].enabled = true;
                    }
                    break;
            }

            ctr = ctr + 1;

        }    
    }

    public void AssignToTarget(Skill skill)
    {
        actionPanel.SetActive(true);
        actionTxt.text = "Choose Target...";
        //foreach (Button b in targetBtns)
        //{
            //b.onClick.AddListener(() => ChooseTarget(skill));
            //b.onClick.AddListener(() => skill.Use(targetList));
            //targetCursor[b.GetComponent<TargetButtons>().targetBtnID].SetActive(true);
  
        //}

        if (skill.target == Skill.Target.ENEMY)
        {
            switch (customManager.holoTurnOrder[0].team)
            {
                case HoloMem.Team.RED:

                    foreach (Button i in targetBtns)
                    {
                        if (i.GetComponent<TargetButtons>().targetBtnID > 2)
                        {
                            i.gameObject.SetActive(true);
                        }
                    }
                    break;

                case HoloMem.Team.BLUE:
                    foreach (Button i in targetBtns)
                    {
                        if (i.GetComponent<TargetButtons>().targetBtnID < 3)
                        {
                            i.gameObject.SetActive(true);
                        }
                    }
                    break;
            }
            
        }

        else if (skill.target == Skill.Target.SELF)
        {
            targetList.Add(customManager.holoTurnOrder[0]);
            targetCursor[customManager.turnOrder[0]].SetActive(true);
            targetConfirmBtns[customManager.turnOrder[0]].gameObject.SetActive(true);
        }

        else if (skill.target == Skill.Target.ENEMIES)
        {
            switch (customManager.holoTurnOrder[0].team)
            {
                case HoloMem.Team.RED:
                    //adds enemies to target list
                    foreach (HoloMem mem in CharSelectionManager.customTeam2)
                    {
                        targetList.Add(mem);
                    }

                    //opens target btns
                    foreach (Button i in targetBtns)
                    {
                        if (i.GetComponent<TargetButtons>().targetBtnID > 2)
                        {
                            targetCursor[i.GetComponent<TargetButtons>().targetBtnID].SetActive(true);
                            targetConfirmBtns[i.GetComponent<TargetButtons>().targetBtnID].gameObject.SetActive(true);
                            i.gameObject.SetActive(true);
                        }
                    }
                    break;

                case HoloMem.Team.BLUE:

                    foreach (HoloMem mem in CharSelectionManager.customTeam1)
                    {
                        targetList.Add(mem);
                    }

                    foreach (Button i in targetBtns)
                    {
                        if (i.GetComponent<TargetButtons>().targetBtnID < 3)
                        {
                            targetCursor[i.GetComponent<TargetButtons>().targetBtnID].SetActive(true);
                            targetConfirmBtns[i.GetComponent<TargetButtons>().targetBtnID].gameObject.SetActive(true);
                            i.gameObject.SetActive(true);
                        }
                    }

                    break;
            }
        }

        else if (skill.target == Skill.Target.ALLIES)
        {
            switch (customManager.holoTurnOrder[0].team)
            {
                case HoloMem.Team.RED:

                    foreach (HoloMem mem in CharSelectionManager.customTeam1)
                    {
                        targetList.Add(mem);
                    }

                    foreach (Button i in targetBtns)
                    {
                        if (i.GetComponent<TargetButtons>().targetBtnID < 3)
                        {
                            targetCursor[i.GetComponent<TargetButtons>().targetBtnID].SetActive(true);
                            targetConfirmBtns[i.GetComponent<TargetButtons>().targetBtnID].gameObject.SetActive(true);
                            i.gameObject.SetActive(true);
                        }
                    }

                    break;

                case HoloMem.Team.BLUE:
                    foreach (HoloMem mem in CharSelectionManager.customTeam2)
                    {
                        targetList.Add(mem);
                    }

                    //opens target btns
                    foreach (Button i in targetBtns)
                    {
                        if (i.GetComponent<TargetButtons>().targetBtnID > 2)
                        {
                            targetCursor[i.GetComponent<TargetButtons>().targetBtnID].SetActive(true);
                            targetConfirmBtns[i.GetComponent<TargetButtons>().targetBtnID].gameObject.SetActive(true);
                            i.gameObject.SetActive(true);
                        }
                    }

                    break;
            }
        }

        foreach (Button i in targetConfirmBtns)
        {
            i.onClick.AddListener(() => skill.Use(targetList));
            i.onClick.AddListener(() => ProcessMove(skill));
        }
    }



    public void ChooseTarget(Skill skill)
    {           
        foreach (Button b in targetBtns)
        {
            if (targetSelected)
            {

                b.onClick.AddListener(() => skill.Use(targetList));

          
            }
        }
    }

    public void DisplayAction()
    {

    }

    public void ProcessMove(Skill skill)
    {
        if (skill.target == Skill.Target.ENEMY)
        {
            actionTxt.text = customManager.holoTurnOrder[0].name + " used " + skill.ssName + " on " + targetList[0].name;
        }

        else if (skill.target == Skill.Target.ALLIES)
        {
            actionTxt.text = customManager.holoTurnOrder[0].name + " used " + skill.ssName;
        }

        else if (skill.target == Skill.Target.ENEMIES)
        {
            actionTxt.text = customManager.holoTurnOrder[0].name + " used " + skill.ssName + " on the opposing team";
        }

        else
        {
            actionTxt.text = customManager.holoTurnOrder[0].name + " used " + skill.ssName;
        }


        foreach (Button b in targetBtns)
        {
            b.gameObject.SetActive(false);
        }

        foreach (Button b in targetConfirmBtns)
        {
            b.gameObject.SetActive(false);
        }

        DisplayUpdatedChar();
        UpdateStamina();
        StartCoroutine(MoveProcessing());


        
    }

    public IEnumerator MoveProcessing()
    {
        yield return new WaitForSeconds(3);
        PlayerStateMachine.currentState = PlayerStateMachine.TurnState.MOVEPROCESSING;
    }

    public void ReadyNextTurn()
    {
        targetList.Clear();
        actionPanel.SetActive(false);
        currentTargetID = 6;
        foreach (Button b in targetConfirmBtns)
        {
            b.onClick.RemoveAllListeners();
        }

        foreach (Button b in skillBtns)
        {
            b.onClick.RemoveAllListeners();
        }

        foreach (GameObject i in targetCursor)
        {
            i.SetActive(false);
        }
        DeathChecker();
        customManager.ChangeTurn();
    }

    public void DeathChecker()
    {
        foreach (HoloMem mem in customManager.holoTurnOrder)
        {
            if (mem.hp == 0)
            {
                int index = customManager.holoTurnOrder.IndexOf(mem);

                allChar[customManager.turnOrder[index]].SetActive(false);

                customManager.turnOrder.RemoveAt(index);
                

                int i = turnOrderPic.Length - customManager.turnOrder.Count;
                turnOrderPic[turnOrderPic.Length - i].SetActive(false);

                if (mem.team == HoloMem.Team.RED)
                {
                    customManager.p1AlivePlayers = customManager.p1AlivePlayers - 1;
                }

                else if (mem.team == HoloMem.Team.BLUE)
                {
                    customManager.p2AlivePlayers = customManager.p2AlivePlayers - 1;
                }

                customManager.holoTurnOrder.Remove(mem);
            }
        }
    }

    public void UpdateStamina()
    {
        switch ((customManager.holoTurnOrder[0].team))
        {
            case HoloMem.Team.RED:
                staminaTxt.text = CustomManager.p1Stamina.ToString();
                staminaTxt.color = UnityEngine.Color.red;
         
                break;

            case HoloMem.Team.BLUE:
                staminaTxt.text = CustomManager.p2Stamina.ToString();
                staminaTxt.color = UnityEngine.Color.blue;

                break;
        }
    }
}
