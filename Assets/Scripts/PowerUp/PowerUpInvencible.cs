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
            if(_currPowerUp == "") PlayerController.Instance.SetPowerUp("Invencible", invencibleMat);
            PlayerController.Instance.SetInvencible(true);
        }

        protected override void EndPowerUp()
        {
            base.EndPowerUp();
            PlayerController.Instance.SetPowerUp("", originalMat);
            PlayerController.Instance.SetInvencible(false);
            
        }

        protected override void FusionPowerUps()
        {
            base.FusionPowerUps();
            if(_currPowerUp != null){

                switch(_currPowerUp){
                    case "Coins":
                        duration = fusionDur;
                        PlayerController.Instance.SetPowerUp("Massive Coins", massiveCoinMat);

                        Invoke(nameof(MassiveCoin), fusionDur - 2f);
                        break;
                }
            }
        }
    #endregion


    #region UNITY-METODOS

    #endregion
}
