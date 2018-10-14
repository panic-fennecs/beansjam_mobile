using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalScript : MonoBehaviour
{
    public static int winner;

    public static void LoadScene(string sceneName, int winner = 0) {
        GlobalScript.winner = winner;
        SceneManager.LoadScene(sceneName);
    }
}
