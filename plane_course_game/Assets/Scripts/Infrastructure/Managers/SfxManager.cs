using System;
using Infrastructure.Abstracts;
using Infrastructure.Events;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;

namespace Infrastructure.Managers
{
    public class SfxManager : Singleton<SfxManager>
    {
        #region Methods

        public void PlayAudioAtPosition(AudioClip audioClip, Vector3 position)
        {
            var go = new GameObject("AudioSource");
            go.transform.position = position;
            var audioSource = go.AddComponent<AudioSource>();
            audioSource.PlayOneShot(audioClip);
            GameplayServices.CoroutineService
                .WaitFor(audioClip.length)
                .OnEnd(() => { Destroy(go); });
        }

        #endregion

        protected override SfxManager GetInstance()
        {
            return this;
        }
    }
}