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
            PlayerController.Instance.ChangeCoinCollectorSize(sizeAmount);
        }

        protected override void EndPowerUp()
        {
            base.EndPowerUp();
            PlayerController.Instance.SetPowerUp("", originalMat);
            PlayerController.Instance.ChangeCoinCollectorSize(1);
        }

        protected override void FusionPowerUps()
        {
            base.FusionPowerUps();
            if(_currPowerUp != null){

                switch(_currPowerUp){
                    case "Invencible":
                        duration = fusionDur;
                        PlayerController.Instance.SetPowerUp("Massive Coins", massiveCoinMat);

                        Invoke(nameof(MassiveCoin), fusionDur - 1f);
                        break;
                }

            }
        }
        #endregion


        #region UNITY-METODOS

        #endregion
    }
}

