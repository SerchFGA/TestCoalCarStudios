using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAssetsmanager : MonoBehaviour
{
    private static SpawnAssetsmanager instance = null;
    public static SpawnAssetsmanager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("no SpawnAssetsManager instance found. Ensure one exist i nthe scene.");
            }
            return instance;
        }
    }

    [Header("Spawn Variables")]
    public GameObject prefabsParent;
    public Transform head;
    public float spawnDistance = 2;

    bool ispreviewPrefab = false;
    private GameObject tempPreviewPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Debug.LogError("no SpawnAssetsManager instance found. Ensure one exist i nthe scene.");
            UnityEngine.Object.DestroyImmediate(this);
            return;
        }
    }

    //Spawn Prefabs call from Spawner Prefabs, use the same position of the temp prefab used
    public void spawnPrefab(GameObject prefabToSpawn)
    {
        GameObject newAsset = Instantiate(prefabToSpawn, prefabsParent.transform);
        newAsset.transform.position = tempPreviewPrefab.transform.position;
        newAsset.transform.rotation = tempPreviewPrefab.transform.rotation;

    }

    //Use Preview Prefab to visualized Prefab to Spawn
    public void appearPreviewPrefab(GameObject prefabToSpawn)
    {
        ispreviewPrefab = true;
        if (tempPreviewPrefab != null)
            Destroy(tempPreviewPrefab);

        tempPreviewPrefab = Instantiate(prefabToSpawn, prefabsParent.transform);
        tempPreviewPrefab.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
    }

    //Delete preview prefab
    public void disapearPreviewPrefab()
    {
        if (tempPreviewPrefab != null)
        {
            Destroy(tempPreviewPrefab);
        }
        ispreviewPrefab = false;
    }
}
