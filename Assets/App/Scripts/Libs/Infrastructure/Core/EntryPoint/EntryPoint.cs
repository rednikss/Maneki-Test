using App.Scripts.Libs.Infrastructure.Core.EntryPoint.Initializable;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private MonoInitializable[] monoInitializables;

        public void Awake()
        {
            foreach (var initializable in monoInitializables)
            {
                initializable.Init();
            }
        }
    }
}