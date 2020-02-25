using UnityEngine;

namespace TicTacToe.Generics
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T> 
    {
        private static T instance;
        public static T Instance {get{return instance;}}
        protected virtual void Awake() 
        {
            if(instance == null || instance != this)
            {
                instance = (T)this;
            }
            else{
                Debug.LogError("Duplicate instance is BlendWeights created");
                Destroy(this);
            }
        }
    }
}
