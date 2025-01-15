using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassiveShoot : MonoBehaviour
{
    #region VARIAVEIS
        public string compareTag = "Enemy";
    #endregion
     
     
    #region METODOS
     
    #endregion
     
     
    #region UNITY-METODOS
        private void Update()
        {
            transform.Translate(transform.forward * 20f * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.CompareTag(compareTag)){
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    #endregion
}
