using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRInteractableSpawnerPrefab : XRSimpleInteractable
{
    [Header("Prefabs Objects")]
    public GameObject previewPrefab;
    public GameObject spawnPrefab;

    //On Hover, call method to apear Preview Prefab
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        SpawnAssetsmanager.Instance.appearPreviewPrefab(previewPrefab);
        base.OnHoverEntered(args);
    }
    //On exit Hover,call method to delete Preview Prefab
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        SpawnAssetsmanager.Instance.disapearPreviewPrefab();
        base.OnHoverExited(args);
    }
    //On Grip Pressed, call method to spawn Prefab
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        SpawnAssetsmanager.Instance.spawnPrefab(spawnPrefab);
        base.OnSelectEntered(args);
    }
}
