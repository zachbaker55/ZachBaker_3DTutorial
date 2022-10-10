using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    float _rotationSpeed = 180;

    [SerializeField] GameObject _parentQuiz;
    [SerializeField] RuntimeData _runtimeData;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter() {
        transform.Find("Spotlight").gameObject.SetActive(true);
        _runtimeData.CurrentFoodMousedOver = name;
    }

    void OnMouseOver() {
        transform.Find("FoodMesh").RotateAround(transform.position, Vector3.up,_rotationSpeed *Time.deltaTime);
    }

    void OnMouseExit() {
        transform.Find("Spotlight").gameObject.SetActive(false);
        _runtimeData.CurrentFoodMousedOver = "";
    }

    void OnMouseDown() {
        if (_runtimeData.CurrentGameplayState == GameplayState.FreeWalk) {
            StartCoroutine(_parentQuiz.GetComponent<FoodQuiz>().FoodSelected(gameObject));
            _runtimeData.CurrentFoodMousedOver = "";
        }
    }

}
