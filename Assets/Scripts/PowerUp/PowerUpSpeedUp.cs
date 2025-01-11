using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    #region VARIAVEIS
        [Header("PowerUp SpeedUp")]
        public float amountToSpeed;
        public Material speedUpMat;
    #endregion


    #region METODOS
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.PowerUpSpeedUp(amountToSpeed);
        PlayerController.Instance.SetPowerUp("Speed Up", speedUpMat);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetSpeed();
        PlayerController.Instance.SetPowerUp("", originalMat);
    }
    #endregion


    #region UNITY-METODOS

    #endregion
}
