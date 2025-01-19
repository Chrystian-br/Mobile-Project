using System.Collections;
using System.Collections.Generic;
using RysCorp.Core.Singleton;
using UnityEngine;

public class ColorManager : Singleton<ColorManager>
{
    #region VARIAVEIS
        public List<Material> materials;
        public List<ColorSetup> colorSetups;
    #endregion
     
     
    #region METODOS
        public void ChangeColorByType(ArtManager.ArtType artType)
        {
            var setup = colorSetups.Find(i => i.artType == artType);

            for(int n = 0; n < materials.Count; n++)
            {
                materials[n].SetColor("_Color", setup.colors[n]);
            }
        }
    #endregion
     
     
    #region UNITY-METODOS
     
    #endregion
}

[System.Serializable]
public class ColorSetup
{
    public ArtManager.ArtType artType;
    public List<Color> colors;
}
