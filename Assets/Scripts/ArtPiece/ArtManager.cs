using System.Collections;
using System.Collections.Generic;
using RysCorp.Core.Singleton;
using UnityEngine;


public class ArtManager : Singleton<ArtManager>
{
    #region VARIAVEIS
        public enum ArtType
        {
            TYPE_01,
            TYPE_02,
            TYPE_03
        }

        public List<ArtSetup> artSetup;
    #endregion
     
     
    #region METODOS
        public ArtSetup GetSetupByType(ArtType artType)
        {
            return artSetup.Find(i => i.artType == artType);
        }
    #endregion
     
     
    #region UNITY-METODOS
     
    #endregion
}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.ArtType artType;
    public GameObject gameObject;
}
