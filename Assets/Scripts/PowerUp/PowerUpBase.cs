using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : CollectableBase
{
    #region VARIAVEIS
        [Header("Power Up")]
        public float duration = 2f;
        public Material originalMat;

        [HideInInspector] public string _currPowerUp;
        [HideInInspector] public string _secPowerUp;
    #endregion


    #region METODOS
    protected override void OnCollect()
    {
        base.OnCollect();
        FusionPowerUps();
        StartPowerUp();
    }

    protected virtual void StartPowerUp()
    {
        Debug.Log("Start Power Up");
        Invoke(nameof(EndPowerUp), duration);
    }

    protected virtual void EndPowerUp()
    {
        Debug.Log("End Power Up");
    }

    protected virtual void FusionPowerUps()
    {
        _currPowerUp = PlayerController.Instance._currentPowerUp;
        _secPowerUp = PlayerController.Instance._secondPowerUp;
    }

    
    #endregion


    #region UNITY-METODOS

    #endregion
}
