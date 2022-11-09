using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPrefabDelete : MonoBehaviour
{
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Delete button - look at Camera
        transform.LookAt(new Vector3(mainCamera.transform.position.x, transform.position.y, mainCamera.transform.position.z));
        transform.forward *= -1;
    }

   
}
