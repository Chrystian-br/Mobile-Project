using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : CollectableBase
{
    #region VARIAVEIS
        [Header("Power Up")]
        public float duration = 2f;
        public Material originalMat;
    #endregion


    #region METODOS
    protected override void OnCollect()
    {
        base.OnCollect();
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
    #endregion


    #region UNITY-METODOS

    #endregion
}
