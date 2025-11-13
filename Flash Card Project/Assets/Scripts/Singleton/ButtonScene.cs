using UnityEngine;

public class ButtonScene : MonoBehaviour
{
    public void LoadOtherScene(int index)
    {
        SceneSwitcher.Instance.LoadOtherScene(index);
    }
    
    public void LoadMainScene()
    {
        SceneSwitcher.Instance.LoadMainScene();
    }
}
