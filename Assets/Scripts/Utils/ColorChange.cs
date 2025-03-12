using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{
    #region VARIAVEIS
        public MeshRenderer meshRenderer;
        public float duration = .2f;
        private Color _startColor = Color.white;
        private Color _correctColor;
    #endregion
     
     
    #region METODOS
        private void OnValidate()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        
        private void LerpColor()
        {
            meshRenderer.materials[0].SetColor("_Color", _startColor);
            meshRenderer.materials[0].DOColor(_correctColor, duration).SetDelay(.5f);
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void Start()
        {
            _correctColor = meshRenderer.materials[0].GetColor("_Color");
            LerpColor();
        }
    #endregion
}
