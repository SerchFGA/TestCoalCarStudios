using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [Header("Rotation speed")]
    public float speed = 25.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.Self);
    }
}
