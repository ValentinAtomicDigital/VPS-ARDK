using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlea : MonoBehaviour
{
    [SerializeField]private List<GameObject> _spawnList = new List<GameObject>();
    [SerializeField] private GameObject _spawnPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnBounceShoes()
    {
        //int numberObjectAlea=Random.Range(0, 4);
        for (int i = 0; i < 1; i++)
        {
            
            Transform _temp = _spawnList[i].transform;
            Instantiate(_spawnPrefab,_temp.position,_spawnPrefab.transform.rotation, _temp.transform);

        }
    }
}
