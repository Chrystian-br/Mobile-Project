using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    #region VARIAVEIS
        public GameObject currentArt;
    #endregion
     
     
    #region METODOS
        public void ChangePiece(GameObject piece)
        {
            if(currentArt != null) Destroy(currentArt);

            currentArt = Instantiate(piece, transform);
            currentArt.transform.localPosition = Vector3.zero;
        }
    #endregion
     
     
    #region UNITY-METODOS
     
    #endregion
}
