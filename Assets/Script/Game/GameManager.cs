using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AROcclusionManager _occlusionManager;
    [SerializeField] private GameObject _mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleOcclusion()
    {
        _occlusionManager=_mainCamera.GetComponent<AROcclusionManager>();
        if (_occlusionManager.enabled)
        {
            _occlusionManager.enabled = false;
        }
        else
        {
            _occlusionManager.enabled = true;
        }


    }
}
