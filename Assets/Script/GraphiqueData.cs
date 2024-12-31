using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GraphiqueData : MonoBehaviour
{
    [SerializeField] private FpsControler _fpsControlerScript;
    [SerializeField] private SliderGeneration _sliderGenerationScript;
    [SerializeField] private ProfilerStats _profilerStatsScript;

    // Création d'un objet Data pour contenir les listes
    [SerializeField] private Data dataStructArCore = new Data { };



    // Classe pour représenter les données à sauvegarder
    [System.Serializable]
    public class Data
    {
        public List<float> FPSList;
        public List<int> ObjectNumberList;
        public List<int> VerticesList;
        public List<int> DrawCallList;
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddData()
    {
        dataStructArCore.FPSList.Add(_fpsControlerScript.GetterValueFps());
        dataStructArCore.ObjectNumberList.Add(_sliderGenerationScript.GetterValueSldier());
        dataStructArCore.VerticesList.Add(_profilerStatsScript.GetterValueVerts());
        dataStructArCore.DrawCallList.Add(_profilerStatsScript.GetterValueDrawCalls());


    }
    public void LoadData()
    {
        // Sérialisation des données en JSON
        string jsonData = JsonUtility.ToJson(dataStructArCore, true); // true pour format lisible

        // Sauvegarde dans un fichier JSON
        string filePath = Path.Combine(Application.persistentDataPath, "DataStruct.json");
        //Ce PC\Galaxy S22\Internal storage\Android\data\com.yourAwesomeAPP\files

        File.WriteAllText(filePath, jsonData);

        // Affichage dans la console pour vérification
        Debug.Log("Fichier JSON créé : " + filePath); // C:\Users\vboutouria\AppData\LocalLow\DefaultCompany\VPS ArCore FPS+Slider
        Debug.Log(jsonData);

        // Lecture du fichier JSON pour vérifier le contenu
        string loadedJson = File.ReadAllText(filePath);
        Data loadedData = JsonUtility.FromJson<Data>(loadedJson);

        // Vérification des données chargées
        Debug.Log("List1 chargée : " + string.Join(", ", loadedData.FPSList));
        Debug.Log("List2 chargée : " + string.Join(", ", loadedData.ObjectNumberList));

    }

}
