using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BounceHelper : MonoBehaviour
{
    #region VARIAVEIS
    [Header("Animation")]
        public float scaleDuration = .2f;
        public float scaleBounce = 1.2f;
        public Ease ease = Ease.OutBack;
    #endregion
     
     
    #region METODOS
        public void Bounce()
        {
            transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
        }
    #endregion
     
     
    #region UNITY-METODOS
        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.A)){
                Bounce();
            }
        }
    #endregion
}
