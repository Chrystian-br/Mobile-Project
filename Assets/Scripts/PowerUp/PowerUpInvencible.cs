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
            else PlayerController.Instance._secondPowerUp = "Invencible";
            
            PlayerController.Instance.SetInvencible(true);
        }

        protected override void EndPowerUp()
        {
            if(PlayerController.Instance._currentPowerUp == "Invencible"){
                base.EndPowerUp();
                PlayerController.Instance.SetPowerUp("", originalMat);
            } else if(PlayerController.Instance._currentPowerUp != "Massive Coins"){
                PlayerController.Instance.SetInvencible(false);
            }

            
            
        }
    #endregion


    #region UNITY-METODOS

    #endregion
}
