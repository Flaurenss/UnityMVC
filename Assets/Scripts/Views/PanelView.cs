using EDAG.Controllers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EDAG.Views
{
    public class PanelView : MonoBehaviour
    {
        public GameObject m_RightNeedle;
        public Image m_RightTrail;
        public GameObject m_LeftNeedle;
        public Image m_LeftTrail;
        public TextMeshProUGUI m_SpeedText;

        private void Awake()
        {
            PanelController.OnAccOnLeft += MoveLeftSphere;
            PanelController.OnAccOnRight += MoveRightSphere;
            PanelController.OnSpeedChange += ChangeSpeed;
        }
        private void OnDestroy()
        {
            PanelController.OnAccOnLeft -= MoveLeftSphere;
            PanelController.OnAccOnRight -= MoveRightSphere;
            PanelController.OnSpeedChange -= ChangeSpeed;
        }
        private void MoveRightSphere(Vector3 needleRotation, float _trailValue)
        {
            RotateRightNeedle(needleRotation);
            RotateRightTrail(_trailValue);
        }
        private void MoveLeftSphere(Vector3 needleRotation, float _trailValue)
        {
            RotateLeftNeedle(needleRotation);
            RotateLeftTrail(_trailValue);
        }

        #region NEEDLES
        private void RotateRightNeedle(Vector3 _needleRotation)
        {
            m_RightNeedle.transform.rotation = Quaternion.Euler(_needleRotation);
        }
        private void RotateLeftNeedle(Vector3 _needleRotation)
        {
            m_LeftNeedle.transform.rotation = Quaternion.Euler(_needleRotation);
        }
        #endregion
        #region TRAILS
        private void RotateRightTrail(float _trailValue)
        {
            m_RightTrail.fillAmount = _trailValue;
        }
        private void RotateLeftTrail(float _trailValue)
        {
            m_LeftTrail.fillAmount = _trailValue;
        }
        #endregion
        #region SPEED
        private void ChangeSpeed(int _speed)
        {
            m_SpeedText.text = _speed.ToString();
        }
        #endregion
    }
}

