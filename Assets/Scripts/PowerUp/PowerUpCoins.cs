using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : PowerUpBase
{
    #region VARIAVEIS
        [Header("PowerUp Coins")]
        public Material coinsMat;
        public float sizeAmount = 7f;
    #endregion


    #region METODOS
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUp("Coins", coinsMat);
        PlayerController.Instance.ChangeCoinCollectorSize(sizeAmount);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetPowerUp("", originalMat);
        PlayerController.Instance.ChangeCoinCollectorSize(1);
    }
    #endregion


    #region UNITY-METODOS

    #endregion
}
