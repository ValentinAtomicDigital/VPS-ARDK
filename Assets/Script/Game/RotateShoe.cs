using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShoe : MonoBehaviour
{
    [SerializeField] private GameObject _anchorShoeNumber1;
    [SerializeField] private GameObject _anchorShoeNumber2;
    [SerializeField] private GameObject _anchorShoeNumber3;
    [SerializeField] private float rotationSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationShoe();
        
    }
    void RotationShoe()
    {
        // Calculer la rotation à appliquer
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Appliquer la rotation sur l'axe Y
        _anchorShoeNumber1.transform.Rotate(0, rotationAmount, 0);
        _anchorShoeNumber2.transform.Rotate(0, rotationAmount, 0);
        _anchorShoeNumber3.transform.Rotate(0, rotationAmount, 0);
    }
}
