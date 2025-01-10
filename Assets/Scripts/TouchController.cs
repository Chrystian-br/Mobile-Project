using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    #region VARIAVEIS
        private Vector3 pastPosition;
        public float velocity = 1.5f;
        public float jumpForce = 5f;

        public Rigidbody rigidBody;

        private bool _canJump;
    #endregion
     
     
    #region METODOS
        public void Move(float speed)
        {
            transform.position += Vector3.right * Time.deltaTime * speed * velocity;
        }

        public void Jump()
        {
            if(_canJump) rigidBody.velocity = Vector3.up * jumpForce;
            _canJump = false;
        }
    #endregion
     
     
    #region UNITY-METODOS
        void Update()
        {
            if(Input.GetMouseButton(0)){
                Move(Input.mousePosition.x - pastPosition.x);
                
                if(Input.mousePosition.y >= pastPosition.y + 20f){
                    Jump();
                }
            }
            pastPosition = Input.mousePosition;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == "Floor"){
                _canJump = true;
            }
        }
    #endregion
}
