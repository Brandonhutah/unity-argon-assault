using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float sceneTransitionSeconds = 5f;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNextScene", sceneTransitionSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

}
