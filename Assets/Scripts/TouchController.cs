using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    #region VARIAVEIS
        private Vector3 pastPosition;
        public float velocity = 1.5f;
    #endregion
     
     
    #region METODOS
        public void Move(float speed)
        {
            transform.position += Vector3.right * Time.deltaTime * speed * velocity;
        }
    #endregion
     
     
    #region UNITY-METODOS
        void Update()
        {
            if(Input.GetMouseButton(0)){
                Move(Input.mousePosition.x - pastPosition.x);
            }
            pastPosition = Input.mousePosition;
        }
    #endregion
}
