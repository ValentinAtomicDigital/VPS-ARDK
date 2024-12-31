using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _valueSlider;
    [SerializeField] private int _numberChildInParent;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI m_TextMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControlNumberChild();
        
    }
    public void ControlNumberChild() 
    {

        _numberChildInParent = _parent.transform.childCount;
        _valueSlider = (int)_slider.value;
        if (_numberChildInParent>_valueSlider)//si le nombre d'objet est supérieur a la valeur du slider on en supprime
        { 
            RemoveChild(_numberChildInParent-_valueSlider);
        }
        if (_numberChildInParent < _valueSlider)//si le nombre d'objet est inférieur a la valeur du slider on en ajoute
        {
            AddChild(_valueSlider - _numberChildInParent);
        }
        m_TextMeshProUGUI.text = "Object : " + _numberChildInParent;

    }
    public void AddChild(int quantity) 
    {
        UnityEngine.Vector3 pos = UnityEngine.Vector3.zero;
        UnityEngine.Quaternion rot = UnityEngine.Quaternion.identity;
        for (int i = 0; i < quantity; i++)
        {
            Instantiate(_prefab,_parent.transform);
        }

    }
    public void RemoveChild(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            Destroy(_parent.transform.GetChild(0).gameObject);
        }
    }
    public int GetterValueSldier()
    {
        return _valueSlider;
    }


}
