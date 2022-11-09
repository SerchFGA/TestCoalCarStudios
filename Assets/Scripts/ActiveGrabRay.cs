using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//Check when Grab ray should be active
public class ActiveGrabRay : MonoBehaviour
{
    [Header("Grab Objects")]
    public GameObject rightGrabRay;
    public XRDirectInteractor rightDirectGrab;

    // Update is called once per frame
    void Update()
    {
        rightGrabRay.SetActive(rightDirectGrab.interactablesSelected.Count == 0);
    }
}
