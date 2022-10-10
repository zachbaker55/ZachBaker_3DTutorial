using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TheRock : MonoBehaviour
{
    [SerializeField] RuntimeData _runtimeData;

    [SerializeField] Dialogue _failDialogue;
    [SerializeField] Dialogue _successDialogue;
    //This could check whatever's stats. It could check, for example, an NPC's stats if they had them
    [SerializeField] Player playerObject;

    // Start is called before the first frame update
    void OnMouseEnter() {
        transform.Find("Spotlight").gameObject.SetActive(true);
    }

    void OnMouseExit() {
        transform.Find("Spotlight").gameObject.SetActive(false);
    }

    void OnMouseDown() {
        if (_runtimeData.CurrentGameplayState == GameplayState.FreeWalk) {
            StartCoroutine(breakRock());
        }
    }

    IEnumerator breakRock() {
        yield return new WaitForEndOfFrame();
        if (playerObject.strengthStat >= 10f){
            GameEvents.InvokeDialogInitiated(_successDialogue);
            Destroy(this.gameObject);
        } else {
            GameEvents.InvokeDialogInitiated(_failDialogue);
        }
    }
}
