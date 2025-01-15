using System.Collections;
using System.Collections.Generic;
using RysCorp.Core.Singleton;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    #region VARIAVEIS
    public Animator animator;
        public List<AnimatorSetup> animatorSetups;

        public enum AnimationType
        {
            IDLE,
            RUN,
            DEAD
        }
    #endregion
     
     
    #region METODOS
        public void Play(AnimationType type, float currentSpeedFactor = 1f)
        {

            foreach(var animation in animatorSetups)
            {
                if(animation.type == type){
                    animator.SetTrigger(animation.trigger);
                    animator.speed = animation.speed * currentSpeedFactor;
                    break;
                }
            }
        }
    #endregion
     
     
    #region UNITY-METODOS

    #endregion
}

[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.AnimationType type;
    public string trigger;
    public float speed = 1f;
}