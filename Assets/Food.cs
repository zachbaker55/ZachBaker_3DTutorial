using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    float _rotationSpeed = 180;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter() {
        transform.Find("Spotlight").gameObject.SetActive(true);
    }

    void OnMouseOver() {
        transform.Find("FoodMesh").Rotate(Vector3.up,_rotationSpeed *Time.deltaTime);
    }

    void OnMouseExit() {
        transform.Find("Spotlight").gameObject.SetActive(false);
    }


}
