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
        public void Play(AnimationType type)
        {
            /*animatorSetups.ForEach(i => {
                if(i.type == type){
                    animator.SetTrigger(i.trigger);
                }
            });*/

            foreach(var animation in animatorSetups)
            {
                if(animation.type == type){
                    animator.SetTrigger(animation.trigger);
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
}