using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class LevelChange : MonoBehaviour
{
    public Animator transition;

    public int sceneBuildIndex;
    public Vector2 playerPosition;
    public float transitionTime = 1f;

    //public VectorValue playerStorage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(LoadLevel(sceneBuildIndex));
        }
    }

    IEnumerator LoadLevel(int sceneBuildIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
