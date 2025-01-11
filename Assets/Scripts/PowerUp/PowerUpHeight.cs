using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeight : PowerUpBase
{
    #region VARIAVEIS
        [Header("PowerUp Height")]
        public Material heightMat;
        public float amountHeight = 2f;
        public float animDuration = .1f;
        public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;
    #endregion


    #region METODOS
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.ChangeHeight(amountHeight, duration, animDuration, ease);
        PlayerController.Instance.SetPowerUp("Height", heightMat);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetHeight();
        PlayerController.Instance.SetPowerUp("", originalMat);
    }
    #endregion


    #region UNITY-METODOS

    #endregion
}
