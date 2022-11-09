using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    [Header("Spawn menu variables")]
    public Transform head;
    public float spawnDistance = 2;

    public GameObject menu;
    public InputActionProperty showButton;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //menu button pressed
        if (showButton.action.WasPressedThisFrame())
            toggleVRMenu();

        //Look at camera menu if is active
        if (menu.activeSelf)
        {
            menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
            menu.transform.forward *= -1;
        }
    }

    //Toggle Menu Canvas
    public void toggleVRMenu()
    {
        menu.SetActive(!menu.activeSelf);
        menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
 
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
