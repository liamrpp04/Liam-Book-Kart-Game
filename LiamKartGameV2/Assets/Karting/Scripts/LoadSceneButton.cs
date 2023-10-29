using UnityEngine;
using UnityEngine.SceneManagement;

namespace KartGame.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        [Tooltip("What is the name of the scene we want to load when clicking the button?")]
        public string SceneName;

        public void LoadTargetScene() 
        {
            SFXManager.PlaySound("button");
            ChangeSceneFadeUI.Instance.ChangeScene(SceneName);
            //SceneManager.LoadScene(SceneName);
            Time.timeScale = 1;
        }
    }
}
