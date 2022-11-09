using UnityEngine;
using UnityEngine.UI;
public enum Prefabs { SpawnBench, SpawnBoat, SpawnBush, SpawnDoubleBench, SpawnFance, SpawnFanceConnector, SpawnFountain, SpawnLamp, SpawnRock, SpawnTrashBin, SpawnTree01, SpawnTree02, SpawnTree03, SpawnTree04, SpawnTree05, SpawnWoodenBin }
public class PrefabScript : MonoBehaviour
{
    [Header("Type of Prefab")]
    public Prefabs usePrefab;

    [Header("UI Object")]
    public Button deleteButton;

    private void Awake()
    {
        SaveSystem.prefabs.Add(this);                           //Add prefab to SaveSystem list
    }

    private void Start()
    {
        if(deleteButton!= null)
            deleteButton.onClick.AddListener(deleteObj);
    }

    public void deleteObj()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        SaveSystem.prefabs.Remove(this);                        //Remove prefab from SaveSystem list
    }

}
