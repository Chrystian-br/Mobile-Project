using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    #region VARIAVEIS
        public string compareTag = "Player";
        
        public float animationCollectDelay = 0.5f;
        public float timeToDestroy = 1f;

        public ParticleSystem pSystem;
        public GameObject floor;

        [Header("Sounds")]
        public AudioSource audioSource;

    #endregion
     
     
    #region METODOS
        protected virtual void Collect()
        {
            OnCollect();
            Invoke("AutoDestroy", timeToDestroy);
        }

        protected virtual void OnCollect()
        {
            if(pSystem != null) pSystem.Play();
            if(audioSource != null) audioSource.Play();
        }

        private void AutoDestroy()
        {
            Destroy(gameObject);
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void OnTriggerEnter(Collider collision)
        {
            if(collision.transform.CompareTag(compareTag)){

                Invoke(nameof(Collect),animationCollectDelay - 0.2f);
            }
        }

        private void Awake()
        {
            if(pSystem != null){
                pSystem.transform.SetParent(null);
                pSystem.collision.AddPlane(floor.transform);
            }
        }
    #endregion
}
