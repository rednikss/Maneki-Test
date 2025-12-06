using System;
using App.Scripts.Game.Entity.Movement.Dash.Config;
using App.Scripts.Libs.Extensions.LayerMask;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Game.Entity.Movement.Dash
{
    public class DashingEntity : MonoBehaviour
    {
        [SerializeField] private DashConfig _dashConfig;
        
        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 _nextPosition;

        private Tween _dashTween;
        
        public void Dash(Vector3 direction)
        {
            if (_dashTween.IsActive()) return;
            
            var dash = ConvertToDash(direction);

            _dashTween = _rigidbody.DOMove(_rigidbody.position + dash, _dashConfig.DashTime)
                .SetEase(_dashConfig.DashEase)
                .SetLink(gameObject);
        }
        
        private Vector3 ConvertToDash(Vector3 direction)
        {
            bool isHorizontalMove = Math.Abs(direction.x) > Math.Abs(direction.z);

            var dash = isHorizontalMove ? Vector3.right * direction.x : Vector3.forward * direction.z;
            
            return dash.normalized * _dashConfig.DashLength;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (_dashConfig.DashLayerMask.IsLayerInMask(collision.gameObject.layer)) return;
            
            _dashTween.Rewind();
            _dashTween?.Kill();
        }
    }
}