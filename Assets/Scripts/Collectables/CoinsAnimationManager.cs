using System.Collections;
using System.Collections.Generic;
using RysCorp.Core.Singleton;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    #region VARIAVEIS
        public List<CollectableCoin> coins;

        [Header("Animation")]
        public float scaleDuration = .2f;
        public float scaleTimeBetweenPieces = .1f;
        public Ease ease = Ease.OutBack;
    #endregion
     
     
    #region METODOS
        public void RegisterCoin(CollectableCoin i)
        {
            if(!coins.Contains(i)){
                coins.Add(i);
                i.transform.localScale = Vector3.zero;
            }
        }

        public void StartAnimations()
        {
            StartCoroutine(ScalePiecesByTime());
        }

        IEnumerator ScalePiecesByTime()
        {
            foreach(var p in coins)
            {
                p.transform.localScale = Vector3.zero;
            }

            Sort();

            yield return null;

            for(int i = 0; i < coins.Count; i++)
            {
                coins[i].transform.DOScale(1, scaleDuration).SetEase(ease);
                yield return new WaitForSeconds(scaleTimeBetweenPieces);
            }
        }

        private void Sort()
        {
            coins = coins.OrderBy(
                x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
        }
    #endregion
     
     
    #region UNITY-METODOS
        public void Start()
        {
            coins = new List<CollectableCoin>();
        }
    #endregion
}
