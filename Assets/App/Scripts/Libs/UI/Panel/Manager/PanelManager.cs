using System.Collections.Generic;
using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.Libs.UI.Panel.Controller;
using UnityEngine;

namespace App.Scripts.Libs.UI.Panel.Manager
{
    public class PanelManager
    {
        private List<IFactory<PanelController>> _factories;

        private readonly List<PanelController> _panels = new();

        public void SetFactories(List<IFactory<PanelController>> factories)
        {
            _factories = factories;
        }
        
        public TController GetPanel<TController>() where TController : PanelController
        {
            for (var i = 0; i < _panels.Count; i++)
            {
                var panel = _panels[i];
                
                if (panel.GetType() != typeof(TController)) continue;
                
                return (TController) panel;
            }

            return CreatePanel(GetFactory<IFactory<TController>>());
        }

        private TFactory GetFactory<TFactory>() where TFactory : class, IFactory<PanelController>
        {
            foreach (var panelFactory in _factories)
            {
                var t = panelFactory.GetType().GetInterface("IFactory`1");
                
                if (t != typeof(TFactory)) continue;
                
                return (TFactory) panelFactory;
            }

            Debug.LogError($"Attempted to create non-existent {typeof(TFactory).Name}!");

            return null;
        }

        private TController CreatePanel<TController>(IFactory<TController> factory) where TController : PanelController
        {
            var panel = factory.Create();
            panel.Hide();
            AddActive(panel);
            return panel;
        }

        private void AddActive(PanelController panel)
        {
            if (_panels.Count != 0) _panels[^1].SetInteractable(false);
            
            _panels.Add(panel);
        }
        
        public void RemoveActive(PanelController panel) 
        {
            if (_panels.Count > 1 && _panels[^1] == panel)
            {
                _panels[^2].SetInteractable(true);
            }
            
            _panels.Remove(panel);
        }

        public void HideAll()
        {
            foreach (var panel in _panels) panel.Hide();
        }
        
        public void DestroyAll()
        {
            while (_panels.Count > 0)
            {
                var panel = _panels[0];
                _panels.RemoveAt(0);
                panel.Destroy();
            }
        }
    }
}