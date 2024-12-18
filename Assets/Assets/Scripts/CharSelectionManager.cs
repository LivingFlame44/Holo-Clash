using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Vector3 = UnityEngine.Vector3;
using System.Runtime.ConstrainedExecution;

public class CharSelectionManager : MonoBehaviour
{
    public static HoloMem[] customTeam1;
    public static HoloMem[] customTeam2;

    public HoloMemManager holoMemManager;
    public CharSelectDisplay charSelectDisplay;

    public int[] p1Team;
    public int[] p2Team;

    public GameObject p1Cursor;
    public GameObject p2Cursor;

    public int p1CursorLoc = 0;
    public int p2CursorLoc = 0;

    public int p1CharNum = 0;
    public int p2CharNum = 0;

    public GameObject[] characters;
    public int charCtr = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
     
    }
    private void OnEnable()
    {
        p2Cursor.GetComponent<RectTransform>().localPosition = new Vector3(characters[p2CursorLoc].GetComponent<RectTransform>().localPosition.x,
                characters[p2CursorLoc].GetComponent<RectTransform>().localPosition.y, characters[p2CursorLoc].GetComponent<RectTransform>().localPosition.z);
        p1Cursor.GetComponent<RectTransform>().localPosition = new Vector3(characters[p1CursorLoc].GetComponent<RectTransform>().localPosition.x,
               characters[p1CursorLoc].GetComponent<RectTransform>().localPosition.y, characters[p1CursorLoc].GetComponent<RectTransform>().localPosition.z);
  
        charSelectDisplay.DisplayP1Character(holoMemManager.holoMems[p1CursorLoc], p1CharNum);
        charSelectDisplay.DisplayP2Character(holoMemManager.holoMems[p2CursorLoc], p2CharNum);
    }
    private void OnDisable()
    {
        p1CursorLoc = 0;
        p2CursorLoc = 0;

        p1CharNum = 0;
        p2CharNum = 0;

        for (int i = 0; i < p1Team.Length; i++)
        {
            p1Team[i] = -1;
            p2Team[i] = -1;
        }
  
        charSelectDisplay.ClearView();
    }
    void Start()
    {
        foreach (HoloMem p in holoMemManager.holoMems)
        {
            Image charIcon = characters[charCtr].GetComponent<Image>();
            charIcon.sprite = p.btnPic;
            charCtr++;
        }
        charSelectDisplay.DisplayP1Character(holoMemManager.holoMems[p1CursorLoc], p1CharNum);
        charSelectDisplay.DisplayP2Character(holoMemManager.holoMems[p2CursorLoc], p2CharNum);
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if both teams are ready
        if (p1Team[2] > -1 && p2Team[2] > -1)
        {
            customTeam1 = new HoloMem[3];
            customTeam2 = new HoloMem[3];

            //updates team data for next scene
            for (int i = 0; i < p1Team.Length; i++)
            {
                customTeam1[i] = Instantiate(holoMemManager.holoMems[p1Team[i]]);
                customTeam1[i].team = HoloMem.Team.RED;

                customTeam2[i] = Instantiate(holoMemManager.holoMems[p2Team[i]]);
                customTeam2[i].team = HoloMem.Team.BLUE;
            }
            SceneManager.LoadScene("Custom1v1");

        }
        
        //wasd Char Select Movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (p1CursorLoc >= 0 && p1CursorLoc <= 8)
            {

            }
            else
            {
                p1CursorLoc = p1CursorLoc - 9;
                MoveP1cursor();
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (p1CursorLoc >= 63 && p1CursorLoc <= 71)
            {

            }
            else
            {
                p1CursorLoc = p1CursorLoc + 9;
                MoveP1cursor();
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (p1CursorLoc == 0 || p1CursorLoc == 9 || p1CursorLoc == 18 || p1CursorLoc == 27 || p1CursorLoc == 36 || p1CursorLoc == 45 
                || p1CursorLoc == 54 || p1CursorLoc == 63)
            {

            }
            else
            {
                p1CursorLoc = p1CursorLoc - 1;
                MoveP1cursor();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (p1CursorLoc == 8 || p1CursorLoc == 17 || p1CursorLoc == 26 || p1CursorLoc == 35 || p1CursorLoc == 44 || p1CursorLoc == 53
                || p1CursorLoc == 62 || p1CursorLoc == 71)
            {

            }
            else
            {
                p1CursorLoc = p1CursorLoc + 1;
                MoveP1cursor();
            }
        }

        //Arrow Keys Movement
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (p2CursorLoc >= 0 && p2CursorLoc <= 8)
            {

            }
            else
            {
                p2CursorLoc = p2CursorLoc - 9;
                MoveP2cursor();
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (p2CursorLoc >= 63 && p2CursorLoc <= 71)
            {

            }
            else
            {
                p2CursorLoc = p2CursorLoc + 9;
                MoveP2cursor();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (p2CursorLoc == 0 || p2CursorLoc == 9 || p2CursorLoc == 18 || p2CursorLoc == 27 || p2CursorLoc == 36 || p2CursorLoc == 45
                || p2CursorLoc == 54 || p2CursorLoc == 63)
            {

            }
            else
            {
                p2CursorLoc = p2CursorLoc - 1;
                MoveP2cursor();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (p2CursorLoc == 8 || p2CursorLoc == 17 || p2CursorLoc == 26 || p2CursorLoc == 35 || p2CursorLoc == 44 || p2CursorLoc == 53
                || p2CursorLoc == 62 || p2CursorLoc == 71)
            {

            }
            else
            {
                p2CursorLoc = p2CursorLoc + 1;
                MoveP2cursor();
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if(Array.Exists(p1Team, element => element == p1CursorLoc))
            {
                if (p1CharNum == 2 && p1CursorLoc == p1Team[0])
                {
                    p1Team[0] = p1Team[1];
                    charSelectDisplay.DisplayP1Character(holoMemManager.holoMems[p1Team[1]], 0);
                }
                if(p1CharNum != 3) 
                {
                    charSelectDisplay.p1Team[p1CharNum].SetActive(false);
                } 
                p1CharNum = p1CharNum -1;
                p1Team[p1CharNum] = -1;
                charSelectDisplay.p1Team[p1CharNum].SetActive(false);
            }
            else
            {
                if (p1CharNum != 2 && p1CursorLoc > holoMemManager.holoMems.Length - 1)
                {

                }
                else
                {
                    charSelectDisplay.p1Team[p1CharNum].SetActive(true);
                    charSelectDisplay.DisplayP1Character(holoMemManager.holoMems[p1CursorLoc], p1CharNum);
                    p1Team[p1CharNum] = p1CursorLoc;
                    p1CharNum++;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Array.Exists(p2Team, element => element == p2CursorLoc))
            {
                if (p2CharNum == 2 && p2CursorLoc == p2Team[0])
                {
                    p2Team[0] = p2Team[1];
                    charSelectDisplay.DisplayP2Character(holoMemManager.holoMems[p2Team[1]], 0);
                }
                if (p2CharNum != 3)
                {
                    charSelectDisplay.p2Team[p2CharNum].SetActive(false);
                }
                p2CharNum = p2CharNum - 1;
                p2Team[p2CharNum] = -1;
                charSelectDisplay.p2Team[p2CharNum].SetActive(false);
            }
            else
            {
                if (p2CharNum != 2 && p2CursorLoc > holoMemManager.holoMems.Length - 1)
                {

                }
                else
                {
                    charSelectDisplay.p2Team[p2CharNum].SetActive(true);
                    charSelectDisplay.DisplayP2Character(holoMemManager.holoMems[p2CursorLoc], p2CharNum);
                    p2Team[p2CharNum] = p2CursorLoc;
                    p2CharNum++;
                }
            }
        }

        //avoids duplicate displays of character
        if (Array.Exists(p1Team, element => element == p1CursorLoc))
        {
            if (p1CharNum != 3)
            {
                charSelectDisplay.p1Team[p1CharNum].SetActive(false);
            }           
        }

        if (Array.Exists(p2Team, element => element == p2CursorLoc))
        {
            if (p2CharNum != 3)
            {
                charSelectDisplay.p2Team[p2CharNum].SetActive(false);
            }
        }


        void MoveP2cursor()
        {
            p2Cursor.GetComponent<RectTransform>().localPosition = new Vector3(characters[p2CursorLoc].GetComponent<RectTransform>().localPosition.x,
                characters[p2CursorLoc].GetComponent<RectTransform>().localPosition.y, characters[p2CursorLoc].GetComponent<RectTransform>().localPosition.z);     
            if (p2CharNum != 3)
            {
                charSelectDisplay.p2Team[p2CharNum].SetActive(true);
                charSelectDisplay.DisplayP2Character(holoMemManager.holoMems[p2CursorLoc], p2CharNum);
            }
        }

        void MoveP1cursor()
        {
            p1Cursor.GetComponent<RectTransform>().localPosition = new Vector3(characters[p1CursorLoc].GetComponent<RectTransform>().localPosition.x,
                characters[p1CursorLoc].GetComponent<RectTransform>().localPosition.y, characters[p1CursorLoc].GetComponent<RectTransform>().localPosition.z);
            if(p1CharNum != 3)
            {    
                charSelectDisplay.p1Team[p1CharNum].SetActive(true);
                charSelectDisplay.DisplayP1Character(holoMemManager.holoMems[p1CursorLoc], p1CharNum);
            }          
        }
    }
}
