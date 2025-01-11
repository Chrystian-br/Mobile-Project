using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : CollectableBase
{
    #region VARIAVEIS
        public Collider coll;
        public bool collect = false;
        public float lerp = 5f;
        public float minDistance = 1f;
    #endregion

    #region METODOS
        protected override void OnCollect()
        {
            base.OnCollect();
            coll.enabled = false;
            collect = true;
            // PlayerController.Instance.Bounce();
            ItemsManager.Instance.AddCoins();
        }

        protected override void Collect()
        {
            OnCollect();
        }
    #endregion

    #region UNITY-METODOS
        private void Start()
        {
            // CoinsAnimationManager.Instance.RegisterCoin(this);
        }

        private void Update()
        {
            if(collect){
                transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);

                if(Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
                {
                    Destroy(gameObject);
                }
            }
        }
    #endregion
}
