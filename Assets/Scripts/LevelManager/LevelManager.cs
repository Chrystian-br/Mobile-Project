using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region VARIAVEIS
        public Transform container;
        public List<GameObject> levels;

        private int _index;
        private GameObject _currentLevel;
    #endregion
     
     
    #region METODOS
        public void SpawnNextLevel()
        {
            if(_currentLevel != null){
                Destroy(_currentLevel);
                _index++;

                if(_index >= levels.Count){
                    ResetLevelIndex();
                }
            }

            _currentLevel = Instantiate(levels[_index], container);
            _currentLevel.transform.localPosition = Vector3.zero;
        }

        private void ResetLevelIndex()
        {
            _index = 0;
        }
    #endregion
     
     
    #region UNITY-METODOS
        public void Awake()
        {
            SpawnNextLevel();
        }
    #endregion
}
