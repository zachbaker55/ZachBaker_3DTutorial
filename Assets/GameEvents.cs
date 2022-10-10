using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueEventArgs : EventArgs
{
    public Dialogue dialoguePayload; 
}

public class StatEventArgs : EventArgs
{
    public string statType; 
    public int statIncrease;
}

public static class GameEvents
{
    public static event EventHandler<DialogueEventArgs> DialogInitiated;
    public static event EventHandler DialogFinished;
    public static event EventHandler<StatEventArgs> StatIncrease;
    
    public static void InvokeDialogInitiated(Dialogue dialog){
        DialogInitiated(null, new DialogueEventArgs {dialoguePayload = dialog});
    }
    public static void InvokeDialogFinished(){
        DialogFinished(null, EventArgs.Empty);
    } 
    
    public static void InvokeStatIncrease(string stat, int increase){
        StatIncrease(null, new StatEventArgs {statType = stat, statIncrease = increase});
    }



}
