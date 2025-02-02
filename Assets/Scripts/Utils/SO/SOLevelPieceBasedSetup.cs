using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOLevelPieceBasedSetup : ScriptableObject
{
    #region VARIAVEIS
        public ArtManager.ArtType artType;

        [Header("Pieces")]
        public List<LevelPieceBase> levelPiecesStart;
        public List<LevelPieceBase> levelPieces;
        public List<LevelPieceBase> levelPiecesEnd;
        
        public int piecesStartNumber = 2;
        public int piecesNumber = 5;
        public int piecesEndNumber = 1;
    #endregion
     
     
    #region METODOS
     
    #endregion
     
     
    #region UNITY-METODOS
     
    #endregion
}
