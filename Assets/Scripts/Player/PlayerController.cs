using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RysCorp.Core.Singleton;
using TMPro;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    #region VARIAVEIS
        //publics
        [Header("Lerp")]
        public Transform target;
        public float lerpVelocity = 5f;

        [Header("Movement")]
        public float speed = 1f;

        [Header("Power Ups")]
        public TextMeshPro uiTextPowerUp;
        public bool invencible = false;
        public GameObject coinCollector;

        [Header("Checks")]        
        public string tagEnemy = "Enemy";
        public string tagEndLine = "EndLine";
        public GameObject endScreen;
        
        public GameObject positionController;

        //privates
        private Vector3 _pos;
        private bool _canRun;
        private float _currentSpeed;
        private Vector3 _startPosition;
        [HideInInspector] public bool _canJump;
        [HideInInspector] public string _currentPowerUp;
    #endregion
     
     
    #region METODOS
        public void StartToRun()
        {
            _canRun = true;
        }

        private void EndGame()
        {
            _canRun = false;
            endScreen.SetActive(true);
        }

        #region POWER UPS
            public void SetPowerUp(string s, Material m)
            {
                _currentPowerUp = s;
                uiTextPowerUp.text = s;
                gameObject.GetComponent<MeshRenderer>().material = m;
            }

            public void PowerUpSpeedUp(float f)
            {
                _currentSpeed = f;
            }

            public void ResetSpeed()
            {
                _currentSpeed = speed;
            }

            public void SetInvencible(bool inv)
            {
                invencible = inv;
            }

            public void ChangeHeight(float amount, float dur, float animDuration, Ease ease)
            {
                positionController.GetComponent<Rigidbody>().useGravity = false;
                _canJump = false;

                positionController.transform.DOMoveY(_startPosition.y + amount, animDuration).SetEase(ease);
                Invoke(nameof(ResetHeight), dur);
            }

            public void ResetHeight()
            {
                positionController.GetComponent<Rigidbody>().useGravity = true;
                _canJump = true;

                positionController.transform.DOMoveY(_startPosition.y, .1f);
            }

            public void ChangeCoinCollectorSize(float amount)
            {
                coinCollector.transform.localScale = Vector3.one * amount;
            }
        #endregion
    #endregion
     
     
    #region UNITY-METODOS
        private void Start()
        {
            _startPosition = transform.position;
            ResetSpeed();
            _canRun = false;
        }

        void Update()
        {
            if(!_canRun) return;

            _pos = target.position;
            _pos.z = transform.position.z;

            transform.position = Vector3.Lerp(transform.position, _pos, lerpVelocity * Time.deltaTime);
            transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == tagEnemy){
                if(!invencible) EndGame();
                else Destroy(collision.gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.tag == tagEndLine){
                EndGame();
            }
        }
    #endregion
}
