using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.Context
{
    public class ProjectContext : MonoBehaviour
    {
        [SerializeField] private ContextInstaller contextInstaller;
        
        private ServiceContainer _container;

        private static ProjectContext _instance;
        
        public static ProjectContext Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                _instance = Resources.Load<ProjectContext>("Project Context");
                _instance = Instantiate(_instance);
                DontDestroyOnLoad(_instance);
                    
                _instance.Init();

                return _instance;
            }
        }

        private void Init()
        {
            _container = new ServiceContainer();
            contextInstaller.Init();
        }

        public ServiceContainer GetContainer() => _container;
    }
}