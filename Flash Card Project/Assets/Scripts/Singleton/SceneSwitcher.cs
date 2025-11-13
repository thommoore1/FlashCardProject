using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string mainScene = "SampleScene";
    [SerializeField] private List<string> otherScenes;
    public static SceneSwitcher Instance {get; private set;}

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void LoadOtherScene(int index)
    {
        LoadScene(otherScenes[index]);
    }
    
    public void LoadMainScene()
    {
        LoadScene(mainScene);
    }
    
    private void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
