using UnityEngine;
using UnityEngine.InputSystem;

public class LeftHandAssetsMenu : MonoBehaviour
{
    [Header("Inputs Left Controller")]
    public InputActionProperty gripPress;
    public InputActionProperty YButton;
    public InputActionProperty XButton;

    [Header("Menus Prefabs")]
    public GameObject assetsMenu1;
    public GameObject assetsMenu2;


    private bool isOnMenu = false;

    // Update is called once per frame
    void Update()
    {
        if (gripPress.action.WasPressedThisFrame())                 //Activate Prefabs menu1
        {
            isOnMenu = true;
            assetsMenu1.SetActive(true);
            assetsMenu2.SetActive(false);
        }

        if (gripPress.action.WasReleasedThisFrame())                //Desactivate Prefabs menus
        {
            isOnMenu = false;
            assetsMenu1.SetActive(false);
            assetsMenu2.SetActive(false);
        }

        if (YButton.action.WasPressedThisFrame() && isOnMenu)       //Change Menu to Menu1
        {
            assetsMenu1.SetActive(true);
            assetsMenu2.SetActive(false);
        }
        if (XButton.action.WasPressedThisFrame() && isOnMenu)       //Change menu to Menu2
        {
            assetsMenu1.SetActive(false);
            assetsMenu2.SetActive(true);
        }
    }
}
