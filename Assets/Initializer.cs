using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{

    [SerializeField] RuntimeData _runtimeData;
    [SerializeField] Dialogue _startingDialogue;
    
    void Awake()
    {
            _runtimeData.CurrentFoodMousedOver = "";
            _runtimeData.CurrentGameplayState = GameplayState.InDialog;
    }

    void Start()
    {
            GameEvents.InvokeDialogInitiated(_startingDialogue);
    }

}
