using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler.Default;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler.Fixed;
using App.Scripts.Libs.Mechanics.Time.Timer;
using App.Scripts.Libs.UI.Panel.Manager;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.Context.Installer
{
    public class ProjectContextInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _projectCanvas;

        [SerializeField] private MonoTickableHandler defaultTickableHandler;
        
        [SerializeField] private FixedTickableHandler fixedTickableHandler;
        
        public override void InstallBindings(ServiceContainer container)
        {
            var panelManager = new PanelManager();
            
            var timer = new Timer();
            defaultTickableHandler.AddTickable(timer);
            
            container.SetServiceSelf(_projectCanvas);
            
            container.SetServiceSelf(panelManager);
            
            container.SetServiceSelf(defaultTickableHandler);
            container.SetServiceSelf(fixedTickableHandler);
            container.SetServiceSelf(timer);
        }
    }
}