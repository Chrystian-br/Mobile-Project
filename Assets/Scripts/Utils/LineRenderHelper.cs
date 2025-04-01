using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderHelper : MonoBehaviour
{
    #region VARIAVEIS
        public LineRenderer lineRenderer;
        public List<Transform> positions;
    #endregion


    #region METODOS

    #endregion


    #region UNITY-METODOS
    void Start()
    {
        lineRenderer.positionCount = positions.Count;
    }

    void Update()
    {
        for(int i = 0; i < positions.Count; i++)
        {
            lineRenderer.SetPosition(i, positions[i].position);
        }
    }
    #endregion

}
