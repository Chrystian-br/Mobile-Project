using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace scripts.PowerUp.PowerUpCoins
{
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
            if(_currPowerUp == "") PlayerController.Instance.SetPowerUp("Coins", coinsMat);
            else{
                _secPowerUp = "Coins";
                FusionPowerUps();
            }
            PlayerController.Instance.ChangeCoinCollectorSize(sizeAmount);
        }

        protected override void EndPowerUp()
        {
            if(PlayerController.Instance._currentPowerUp == "Coins"){
                base.EndPowerUp();
                PlayerController.Instance.SetPowerUp("", originalMat);
            } else if(PlayerController.Instance._currentPowerUp != "Massive Coins"){
                PlayerController.Instance.ChangeCoinCollectorSize(1);
            }
        }
        #endregion


        #region UNITY-METODOS

        #endregion
    }
}

