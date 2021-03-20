using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to close the game.
/// </summary>
public class UICloseButtonScript : MonoBehaviour
{
    public void CloseApp()
    {
        Application.Quit();
    }
}
