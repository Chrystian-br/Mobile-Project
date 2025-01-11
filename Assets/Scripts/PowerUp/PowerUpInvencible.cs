using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : PowerUpBase
{
    #region VARIAVEIS
        [Header("PowerUp Invencible")]
        public Material invencibleMat;
    #endregion


    #region METODOS
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUp("Invencible", invencibleMat);
        PlayerController.Instance.SetInvencible(true);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetPowerUp("", originalMat);
        PlayerController.Instance.SetInvencible(false);
        
    }
    #endregion


    #region UNITY-METODOS

    #endregion
}
