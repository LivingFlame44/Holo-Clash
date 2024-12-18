using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStateMachine : MonoBehaviour
{
    public CustomCharDisplay customCharDisplay;
    public CustomManager customManager;
    public enum TurnState
    {
        PROCESSING,
        ATKCHOOSE,
        MOVEPROCESSING,
        WAITING,
    }

    public static TurnState currentState;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<CustomManager>();
        currentState = TurnState.PROCESSING;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case TurnState.PROCESSING: 
                customCharDisplay.DisplayCurrentMemberInfo(customManager.holoTurnOrder[0]);
                currentState = TurnState.ATKCHOOSE;  
                break;

            case TurnState.ATKCHOOSE:
                break;

            case TurnState.MOVEPROCESSING:
                customCharDisplay.ReadyNextTurn();
                currentState = TurnState.PROCESSING;
                break;

            case TurnState.WAITING:break;
        }
    }

    public void ChooseTarget()
    {
        
    }
}
