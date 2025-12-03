using App.Scripts.Libs.Infrastructure.Core.EntryPoint.Initializable;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.Context
{
    public class ContextInstaller : MonoInitializable
    {
        [SerializeField] private MonoInstaller[] monoInstallers;

        public override void Init()
        {
            var container = ProjectContext.Instance.GetContainer();
            
            foreach (var monoInstaller in monoInstallers)
            {
                monoInstaller.InstallBindings(container);
            }
        }
    }
}
