using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FpsControler : MonoBehaviour
{
    private float deltaTime = 0.0f;
    [SerializeField] private TextMeshProUGUI m_TextMeshProUGUI;
    [SerializeField] private float fps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        // Calcul des FPS
        fps = Mathf.CeilToInt(1.0f / deltaTime);
        m_TextMeshProUGUI.text = "FPS : " + fps;
    }
    public float GetterValueFps()
    {
        return fps;
    }
}
