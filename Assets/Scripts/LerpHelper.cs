using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHelper : MonoBehaviour
{
    #region VARIAVEIS
        public Transform target;
        public float lerpVelocity = 5f;
    #endregion
     
     
    #region METODOS
     
    #endregion
     
     
    #region UNITY-METODOS
        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, target.position, lerpVelocity * Time.deltaTime);
        }
    #endregion
}
