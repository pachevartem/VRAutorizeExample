using System;
using UnityEngine;

namespace VRGame
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : MonoBehaviour
    {
        private AudioSource _audio; //магнитофон

        [Header("Перетяни сюда музыку для сбора ключа")]
        public AudioClip money; //касета

        [Header("Перетяни сюда музыку для момента разблокировки преграды")]
        public AudioClip forKeyManager; //касета

        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
        }

        private void Start()
        {
            var allKey = FindObjectsOfType<Key>();
            if (allKey.Length != 0)
            {
                foreach (var key in allKey)
                {
                    key.OnKey += PlayMoney;
                }
            }

            KeyManager.OnKeyManager += PlayKetManager;
        }

        void PlayMoney()
        {
            _audio.clip = money;
            _audio.Play();
        }

        void PlayKetManager()
        {
            Debug.Log("KEY MUSIC");
            AudioSource.PlayClipAtPoint(forKeyManager, Camera.main.transform.position);
            _audio.clip = forKeyManager;
            _audio.Play();
        }

        private void OnDisable() //TODO: очень плохо, так как выключенные объекты не найдутся
        {
            var allKey = FindObjectsOfType<Key>();
            if (allKey.Length != 0)
            {
                foreach (var key in allKey)
                {
                    key.OnKey -= PlayMoney;
                }
            }

            KeyManager.OnKeyManager -= PlayKetManager;
        }
    }
}