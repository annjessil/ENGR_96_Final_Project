using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonSceneChange : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Forest1 (richard)");
    }
}
