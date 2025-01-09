using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : CollectableBase
{
    #region METODOS
        protected override void OnCollect()
        {
            base.OnCollect();
            ItemsManager.Instance.AddCoins();
        }
    #endregion
}
