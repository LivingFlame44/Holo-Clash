using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CharSelectDisplay : MonoBehaviour
{
    public HoloMem holoMem;

    public GameObject[] p1Team;
    public GameObject[] p2Team;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayP1Character(HoloMem holoMem, int p1CharNum)
    {
        p1Team[p1CharNum].GetComponentInChildren<TextMeshProUGUI>().text = holoMem.name;
        p1Team[p1CharNum].GetComponent<Image>().sprite = holoMem.infoPic;
    }

    public void DisplayP2Character(HoloMem holoMem, int p2CharNum)
    {
        p2Team[p2CharNum].GetComponentInChildren<TextMeshProUGUI>().text = holoMem.name;
        p2Team[p2CharNum].GetComponent<Image>().sprite = holoMem.infoPic;

    }

    public void ClearView()
    {
        for (int i = 1; i < p1Team.Length; i++)
        {
            p1Team[i].SetActive(false);
            p2Team[i].SetActive(false);
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
}
