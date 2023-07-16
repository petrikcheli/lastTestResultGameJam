using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMapMenu : MonoBehaviour
{
    public void ExitInMenu()
    {
        SceneManager.LoadScene(0);
    }
}
