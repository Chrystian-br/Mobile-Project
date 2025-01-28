using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHelper : MonoBehaviour
{
    #region VARIAVEIS
        public List<Transform> positions;
        public float duration = 1f;

        private int _index = 0;
    #endregion
     
     
    #region METODOS
        IEnumerator StartMovement()
        {
            float time = 0;

            while(true)
            {
                var currentPosition = transform.position;

                while(time < duration)
                {
                    transform.position = Vector3.Lerp(currentPosition, positions[_index].transform.position, (time/duration));
                    time += Time.deltaTime;
                    yield return null;
                }

                NextPosition();
                
                time = 0;

                yield return null;
            }
        }

        public void NextPosition()
        {
            _index++;
            if(_index >= positions.Count) _index = 0;
        }
    #endregion
     
     
    #region UNITY-METODOS
        public void Start()
        {
            transform.position = positions[0].transform.position;
            NextPosition();
            StartCoroutine(StartMovement());
        }
    #endregion
}
