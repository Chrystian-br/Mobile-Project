using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region VARIAVEIS
        public Transform container;
        public List<GameObject> levels;

        [Header("Pieces")]
        
        public List<SOLevelPieceBasedSetup> levelPieceBasedSetups;

        public float timeBetweenPieces = .3f;

        [SerializeField] private int _index;
        private GameObject _currentLevel;
        private SOLevelPieceBasedSetup _currSetup;
        private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
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

        private void CreateLevelPieces()
        {
            StartCoroutine(CreateLevelPiecesCoroutine());
        }

        private void RandomLevelPiece(List<LevelPieceBase> list)
        {
            var piece = list[Random.Range(0, list.Count)];
            var spawnedPiece = Instantiate(piece, container);
            
            if(_spawnedPieces.Count > 0){
                var lastPiece = _spawnedPieces[_spawnedPieces.Count-1];
                
                spawnedPiece.transform.position = lastPiece.endPiece.position;
            }
            else{
                spawnedPiece.transform.localPosition = Vector3.zero;
            }

            foreach(var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
            {
                p.ChangePiece(ArtManager.Instance.GetSetupByType(_currSetup.artType).gameObject);
            }

            _spawnedPieces.Add(spawnedPiece);

        }

        IEnumerator CreateLevelPiecesCoroutine()
        {
            CleanSpawnedPieces();

            if(_currSetup != null){
                _index++;

                if(_index >= levelPieceBasedSetups.Count){
                    ResetLevelIndex();
                }
            }

            _currSetup = levelPieceBasedSetups[_index];

            for(int i = 0; i < _currSetup.piecesStartNumber; i++)
            {
                RandomLevelPiece(_currSetup.levelPiecesStart);
                yield return new WaitForSeconds(timeBetweenPieces);
            }

            for(int i = 0; i < _currSetup.piecesNumber; i++)
            {
                RandomLevelPiece(_currSetup.levelPieces);
                yield return new WaitForSeconds(timeBetweenPieces);
            }

            for(int i = 0; i < _currSetup.piecesEndNumber; i++)
            {
                RandomLevelPiece(_currSetup.levelPiecesEnd);
                yield return new WaitForSeconds(timeBetweenPieces);
            }
        }

        private void CleanSpawnedPieces()
        {
            for(int i = _spawnedPieces.Count-1; i >= 0; i--)
            {
                Destroy(_spawnedPieces[i].gameObject);
            }

            _spawnedPieces.Clear();
        }
    #endregion
     
     
    #region UNITY-METODOS
        public void Awake()
        {
            CreateLevelPieces();
        }
    #endregion
}
