using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    bool isCreated = false;
    bool isInvoked = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
		Invoke("LoadNextScene", 2f);
	}
        
    void LoadNextScene()
    {

            SceneManager.LoadScene(1);
        
    }
}
