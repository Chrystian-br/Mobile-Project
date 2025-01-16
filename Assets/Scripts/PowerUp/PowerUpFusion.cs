using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFusion : PowerUpBase
{
    #region VARIAVEIS
            public Material massiveCoinMat;
            public GameObject massiveShoot;
    #endregion
     
     
    #region METODOS
        protected virtual void MassiveCoin()
        {
            Instantiate(massiveShoot, PlayerController.Instance.transform.position, PlayerController.Instance.transform.rotation);
        }
        
        protected override void FusionPowerUps()
        {
            base.FusionPowerUps();

            // COINS
            if(_currPowerUp == "Coins"){
                
                base.StartPowerUp();
                switch(_secPowerUp){
                    case "Invencible":
                        PlayerController.Instance.SetPowerUp("Massive Coins", massiveCoinMat);

                        Invoke(nameof(MassiveCoin), duration - 1f);
                        break;
                    case "Height":
                        break;
                    
                }
            }

            // INVENCIBLE
            if(_currPowerUp == "Invencible"){

                switch(_secPowerUp){
                    case "Coins":
                        PlayerController.Instance.SetPowerUp("Massive Coins", massiveCoinMat);

                        Invoke(nameof(MassiveCoin), duration - 1f);
                        break;
                }
            }
        }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        if(PlayerController.Instance._currentPowerUp == "Massive Coins") PlayerController.Instance.SetPowerUp("", originalMat);
        PlayerController.Instance.SetInvencible(false);
        PlayerController.Instance.ChangeCoinCollectorSize(1);
    }
    #endregion


    #region UNITY-METODOS

    #endregion
}
