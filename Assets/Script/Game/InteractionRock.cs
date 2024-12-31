using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickRock()
    {
        Destroy(this.gameObject);
    }
}
