using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

namespace UnityEngine
{
    public class ChangeSceneFadeUI : MonoBehaviour
    {
        public static ChangeSceneFadeUI Instance;
        [SerializeField] private Image fadeImage;
        [SerializeField] private float fadeTime = 0.7f;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                fadeImage.gameObject.SetActive(true);

                fadeImage.DOFade(0, fadeTime).SetDelay(0.2f).OnComplete(() =>
                {
                    fadeImage.gameObject.SetActive(false);
                });

                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ChangeScene(string targetScene, float delay = 0f)
        {
            fadeImage.gameObject.SetActive(true);

            fadeImage.DOFade(1, fadeTime).SetDelay(delay).OnComplete(() =>
            {
                SceneManager.LoadSceneAsync(targetScene).completed += OnSceneLoaded;
            });
        }

        private void OnSceneLoaded(AsyncOperation op)
        {
            op.completed -= OnSceneLoaded;

            fadeImage.DOFade(0, fadeTime).OnComplete(() =>
            {
                fadeImage.gameObject.SetActive(false);
            });
        }
    }
}
