using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataAdmin : MonoBehaviour
{
    [SerializeField] GameData infogame;
    string nameArchive;
    private void Start()
    {
        string nameArchive = Application.persistentDataPath + "/GameData";
        DataSave();
        LoadData();
    }

    public void DataSave()
    {


        //Convierte un valor en un string con formato Json
        string json = JsonUtility.ToJson(infogame);



        //Codigo si no existe el archivo
        if (File.Exists(nameArchive) == false)
        {
            //Crear un archivo de juego en una ubicacion predefinida segun el dispositivo 
            File.CreateText(nameArchive).Close();
        }
        File.WriteAllText(nameArchive, json);

    }

    public void LoadData()
    {
        string json = File.ReadAllText(nameArchive);
        Debug.Log(json);
        infogame = JsonUtility.FromJson<GameData>(json);

    }
}
