using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

//Check when teleport Ray should be active
public class ActiveTeleportationRay : MonoBehaviour
{
    [Header("Teleport Objects")]
    public GameObject rightTeleportation;
    public InputActionProperty rightActivate;

    [Header("Grabing Objects")]
    public InputActionProperty rightCancel;
    public XRRayInteractor rightRay;

    // Update is called once per frame
    void Update()
    {
        bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal, out int rightNumber, out bool rightValid);

        // Activate Teleportation Ray if Not over Canvas, Not pressing the grip or tigger button 
        rightTeleportation.SetActive(!isRightRayHovering && rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1);
    }
}
