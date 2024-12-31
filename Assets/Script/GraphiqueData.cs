using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GraphiqueData : MonoBehaviour
{
    [SerializeField] private FpsControler _fpsControlerScript;
    [SerializeField] private SliderGeneration _sliderGenerationScript;
    [SerializeField] private ProfilerStats _profilerStatsScript;

    // Cr�ation d'un objet Data pour contenir les listes
    [SerializeField] private Data dataStructArCore = new Data { };



    // Classe pour repr�senter les donn�es � sauvegarder
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
        // S�rialisation des donn�es en JSON
        string jsonData = JsonUtility.ToJson(dataStructArCore, true); // true pour format lisible

        // Sauvegarde dans un fichier JSON
        string filePath = Path.Combine(Application.persistentDataPath, "DataStruct.json");
        //Ce PC\Galaxy S22\Internal storage\Android\data\com.yourAwesomeAPP\files

        File.WriteAllText(filePath, jsonData);

        // Affichage dans la console pour v�rification
        Debug.Log("Fichier JSON cr�� : " + filePath); // C:\Users\vboutouria\AppData\LocalLow\DefaultCompany\VPS ArCore FPS+Slider
        Debug.Log(jsonData);

        // Lecture du fichier JSON pour v�rifier le contenu
        string loadedJson = File.ReadAllText(filePath);
        Data loadedData = JsonUtility.FromJson<Data>(loadedJson);

        // V�rification des donn�es charg�es
        Debug.Log("List1 charg�e : " + string.Join(", ", loadedData.FPSList));
        Debug.Log("List2 charg�e : " + string.Join(", ", loadedData.ObjectNumberList));

    }

}
