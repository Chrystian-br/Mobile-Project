using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RysCorp.Core.Singleton;

public class ItemsManager : Singleton<ItemsManager>
{
    #region VARIAVEIS
        public SOInt coins;
        public SOInt kills;
        
        public TextMeshProUGUI coinText;
        public TextMeshProUGUI killText;
    #endregion
     
     
    #region METODOS
        private void Reset()
        {
            coins.count = 0;
            if(kills != null) kills.count = 0;
        }

        public void AddCoins(int amount = 1)
        {
            coins.count += amount;
            coinText.text = coins.count + " x";
        }

        public void AddKills(int amount = 1)
        {
            kills.count += amount;
            // killText.text = "x " + kills.count;
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void Start()
        {
            Reset();
        }
    #endregion
}
