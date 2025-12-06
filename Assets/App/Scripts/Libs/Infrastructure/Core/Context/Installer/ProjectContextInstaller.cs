using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using App.Scripts.Libs.Mechanics.Time.Handler;
using App.Scripts.Libs.Mechanics.Time.Timer;
using App.Scripts.Libs.UI.Panel.Manager;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.Context.Installer
{
    public class ProjectContextInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _projectCanvas;

        [SerializeField] private MonoTickableHandler tickableHandler;
        
        public override void InstallBindings(ServiceContainer container)
        {
            container.SetServiceSelf(_projectCanvas);
            
            var panelManager = new PanelManager();
            container.SetServiceSelf(panelManager);
            
            container.SetServiceSelf(tickableHandler);

            var timer = new Timer();
            tickableHandler.AddTickable(timer);
            container.SetServiceSelf(timer);
        }
    }
}