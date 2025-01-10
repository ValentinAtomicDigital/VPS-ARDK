using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCycleShoes : MonoBehaviour
{
    [SerializeField] private float _compteur=0;
    [SerializeField] private float _dureeMax=5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _compteur += Time.deltaTime;
        if (_compteur>_dureeMax)
        {
            Destroy(this.gameObject);
        }
        
    }
}
