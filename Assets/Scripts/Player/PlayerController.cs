using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region VARIAVEIS
        //publics
        [Header("Lerp")]
        public Transform target;
        public float lerpVelocity = 5f;

        [Header("Movement")]
        public float speed = 1f;

        public string tagEnemy = "Enemy";

        //privates
        private Vector3 _pos;
        private bool _canRun;
    #endregion
     
     
    #region METODOS
     
    #endregion
     
     
    #region UNITY-METODOS
        private void Start()
        {
            _canRun = true;
        }

        void Update()
        {
            if(!_canRun) return;

            _pos = target.position;
            _pos.z = transform.position.z;

            transform.position = Vector3.Lerp(transform.position, _pos, lerpVelocity * Time.deltaTime);
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == tagEnemy){
                _canRun = false;
            }
        }
    #endregion
}
