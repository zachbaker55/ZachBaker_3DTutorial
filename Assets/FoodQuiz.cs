using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodQuiz : MonoBehaviour
{
    [SerializeField] Dialogue _dialogue;
    [SerializeField] Dialogue _correctChoiceDialogue;
    [SerializeField] Dialogue _incorrectChoiceDialogue;

    [SerializeField] GameObject _correctFood;
    void OnTriggerEnter()
    {
        GameEvents.InvokeDialogInitiated(_dialogue);
    }
    public IEnumerator FoodSelected(GameObject food)
    {
        yield return new WaitForEndOfFrame();

        if (food == _correctFood) {
            GameEvents.InvokeDialogInitiated(_correctChoiceDialogue);
            GameEvents.InvokeStatIncrease("speed",5);
        } else {
            GameEvents.InvokeDialogInitiated(_incorrectChoiceDialogue);
        }
        Destroy(food);
        GameEvents.InvokeStatIncrease("strength",2);
    }
}