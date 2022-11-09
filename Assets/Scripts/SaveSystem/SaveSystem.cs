using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public enum PrefType { SpawnBench, SpawnBoat, SpawnBush, SpawnDoubleBench, SpawnFance, SpawnFanceConnector, SpawnFountain, SpawnLamp, SpawnRock, SpawnTrashBin, SpawnTree01, SpawnTree02, SpawnTree03, SpawnTree04, SpawnTree05, SpawnWoodenBin }

public class SaveSystem : MonoBehaviour
{
    [Header("Prefabs Objects")]
    public GameObject[] AllPrefabs;
    public GameObject parentPrefabs;

    //List of prefabs on scene
    public static List<PrefabScript> prefabs = new List<PrefabScript>();

    //path to save Data
    const string prefabSubFolder = "/prefabSaveData";
    const string prefabCount = "/prefabSaveData.count";

    public void SavePrefab(string slotSave)                                                     //Save method call from UI Slots buttons
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + prefabSubFolder + slotSave;
        string countPath = Application.persistentDataPath + prefabCount + slotSave;

        //Create file to save the number of prefabs created
        FileStream countStream = new FileStream(countPath, FileMode.Create);
        formatter.Serialize(countStream, prefabs.Count);
        countStream.Close();

        for (int i = 0; i < prefabs.Count; i++)                                                 //Create files to save prefabs
        {
            FileStream stream = new FileStream(path + i, FileMode.Create);
            PrefabsData data = new PrefabsData(prefabs[i]);

            formatter.Serialize(stream, data);
            stream.Close();
        }

    }

    public void LoadPrefabs(string slotLoad)                                                    //Load method call from UI Slots buttons
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + prefabSubFolder + slotLoad;
        string countPath = Application.persistentDataPath + prefabCount + slotLoad;

        int prefCount = 0;
        if (File.Exists(countPath))
        {
            FileStream countStream = new FileStream(countPath, FileMode.Open);
            prefCount = (int)formatter.Deserialize(countStream);
            countStream.Close();
        }
        else
        {
            Debug.LogError("Path not found in" + countPath);
        }

        for (int i = 0; i < prefCount; i++)
        {
            if (File.Exists(path+i))
            {
                FileStream stream = new FileStream(path + i, FileMode.Open);
                PrefabsData data = formatter.Deserialize(stream) as PrefabsData;
                stream.Close();

                                                                                                            //instantiate Prefabs on Scene
                string prefabType = data.prefabType;
                Vector3 position = new Vector3(data.position[0], data.position[1], data.position[2]);
                Vector3 rotation = new Vector3(data.rotation[0], data.rotation[1], data.rotation[2]);
                Vector3 scale = new Vector3(data.scale[0], data.scale[0], data.scale[0]);

                                                                                                            //Check what type of prefab to instantiate
                for (int y = 0; y < AllPrefabs.Length; y++)                                                         
                {
                    string prefType = AllPrefabs[y].GetComponent<PrefabScript>().usePrefab.ToString();
                    if (prefType == prefabType)
                    {
                        GameObject newAsset = Instantiate(AllPrefabs[y], parentPrefabs.transform);          //Instantiate loaded prefab and set pos/rot/scale

                        newAsset.transform.position = position;
                        newAsset.transform.eulerAngles = rotation;
                        newAsset.transform.localScale = scale;
                    }
                }
                                                                                                            //end Instantiate Prefab on Scene

            }
            else
            {
                Debug.LogError("Path not found in" + path + i);
            }
            
        }

    }
}
