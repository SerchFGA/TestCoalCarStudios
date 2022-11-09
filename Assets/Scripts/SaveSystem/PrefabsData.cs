using UnityEngine;

[System.Serializable]
public class PrefabsData 
{
    public string prefabType;

    public float[] position;
    public float[] rotation;
    public float[] scale;

    public PrefabsData(PrefabScript prefab)
    {
        prefabType = prefab.usePrefab.ToString();

        Vector3 prefabPos = prefab.transform.position;
        position = new float[]
        {
            prefabPos.x, prefabPos.y, prefabPos.z
        };

        Vector3 prefabRot = prefab.transform.eulerAngles;
        rotation = new float[]
        {
            prefabRot.x, prefabRot.y, prefabRot.z
        };

        Vector3 prefabScale = prefab.transform.localScale;
        scale = new float[]
        {
            prefabScale.x, prefabScale.y, prefabScale.z
        };
    }
}
