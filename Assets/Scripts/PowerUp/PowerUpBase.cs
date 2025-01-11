using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : CollectableBase
{
    #region VARIAVEIS
        [Header("Power Up")]
        public float duration = 2f;
        public float fusionDur = 4f;
        public Material originalMat;

        public Material massiveCoinMat;
        public GameObject massiveShoot;

        public Transform shootSpawn;

        [HideInInspector] public string _currPowerUp;
    #endregion


    #region METODOS
    protected override void OnCollect()
    {
        base.OnCollect();
        //PowerUpFusion.Instance.Fusion();
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
    }

    protected virtual void MassiveCoin()
    {
        Instantiate(massiveShoot, PlayerController.Instance.transform.position, PlayerController.Instance.transform.rotation);
    }
    #endregion


    #region UNITY-METODOS

    #endregion
}
