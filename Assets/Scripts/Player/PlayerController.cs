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

        [Header("Animation")]
        public AnimatorManager animatorManager;
        
        public GameObject positionController;

        [Header("VFX")]
        public ParticleSystem pSystemKill;

        [Header("Limits")]
        public Vector2 limitVector = new Vector2(-11,-2);

        //privates
        private Vector3 _pos;
        private bool _canRun;
        private float _currentSpeed;
        private Vector3 _startPosition;
        [HideInInspector] public string _currentPowerUp;
        [HideInInspector] public string _secondPowerUp;
        private float _baseSpeedToAnimation = 9f;
        [SerializeField] public BounceHelper bounceHelper;
    #endregion
     
     
    #region METODOS
        public void StartToRun()
        {
            _canRun = true;
            animatorManager.Play(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseSpeedToAnimation);
        }

        private void EndGame(AnimatorManager.AnimationType animationType)
        {
            _canRun = false;
            animatorManager.Play(animationType);
            endScreen.SetActive(true);
        }

        private void MoveBack()
        {
            transform.DOMoveZ(-1f, .3f).SetRelative();
        }

        public void Bounce()
        {
            bounceHelper.Bounce();
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
                positionController.transform.DOMoveY(_startPosition.y + amount, animDuration).SetEase(ease);
                Invoke(nameof(ResetHeight), dur);
            }

            public void ResetHeight()
            {
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

            if(_pos.x < limitVector.x) _pos.x = limitVector.x;
            else if(_pos.x > limitVector.y) _pos.x = limitVector.y;

            transform.position = Vector3.Lerp(transform.position, _pos, lerpVelocity * Time.deltaTime);
            transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == tagEnemy){
                if(!invencible) {
                    EndGame(AnimatorManager.AnimationType.DEAD);
                    MoveBack();
                    pSystemKill.Play();
                }
                else Destroy(collision.gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.tag == tagEndLine){
                EndGame(AnimatorManager.AnimationType.IDLE);;
            }
        }
    #endregion
}
