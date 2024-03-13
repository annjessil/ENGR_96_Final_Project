using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    static BGM instance;

    // Drag in the .mp3 files here, in the editor
    public AudioClip[] MusicClips;

    public AudioSource Audio;

    // Singelton to keep instance alive through all scenes
    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);

        // Hooks up the 'OnSceneLoaded' method to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Called whenever a scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        // Replacement variable (doesn't change the original audio source)
        AudioSource source = gameObject.AddComponent<AudioSource>();
        // Plays different music in different scenes
        switch (scene.name)
        {
            case "Menu":
                source.clip = MusicClips[0];
                break;
            case "Forest1 (richard)":
                source.clip = MusicClips[1];
                break;
            case "Annmarie's Scene":
                source.clip = MusicClips[2];
                break;
            case "Kaylen's Scene":
                source.clip = MusicClips[3];
                break;
            case "EndScene":
                source.clip = MusicClips[4];
                break;
            default:
                source.clip = MusicClips[1];
                break;
        }

        // Only switch the music if it changed
        if (source.clip != Audio.clip)
        {
            Audio.enabled = false;
            Audio.clip = source.clip;
            Audio.enabled = true;
        }
    }
}
