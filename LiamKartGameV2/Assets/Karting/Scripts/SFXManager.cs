using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    [System.Serializable]
    public class SoundData
    {
        public string id;
        public AudioClip audioClip;
    }

    [SerializeField] private List<SoundData> soundDataList = new List<SoundData>();
    [SerializeField] private AudioSource effectSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void PlaySound(string id)
    {
        Instance.DoPlaySound(id);
    }

    public void DoPlaySound(string id)
    {
        for (int i = 0; i < soundDataList.Count; i++)
        {
            if (soundDataList[i].id.Equals(id))
            {
                effectSource.PlayOneShot(soundDataList[i].audioClip);
                return;
            }
        }
    }
}
