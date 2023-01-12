using Assets.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
namespace EDAG.Controllers
{
    public class PanelController
    {
        #region EVENTS
        public delegate void VelocityDelegate(int _speed);
        public static VelocityDelegate OnSpeedChange;
        public delegate void EngineDelegate(Vector3 _needleValue, float _trailValue);
        public static EngineDelegate OnAccOnLeft;
        public static EngineDelegate OnAccOnRight;
        #endregion
        private DataContainerSO m_EngineData;
        private float RightActualNeedleValue = 0;
        public float LeftActualNeedleValue = 0;
        public PanelController(DataContainerSO _so)
        {
            m_EngineData = _so;
            SetResolution();
        }
        private void SetResolution() 
        {
#if !UNITY_EDITOR
            Screen.SetResolution(1280,480,false);

#endif
        }
        public void AccelOn()
        {
            ManageRightNeedle_Up();
            ManageLeftNeedle_Up();
        }
        public void AccelOff() 
        {
            ManageRightNeedle_Down();
            ManageLeftNeedle_Down();
        }
        #region SPHERE MANAGERS
        private void ManageRightNeedle_Up()
        {
            if (RightActualNeedleValue > m_EngineData.m_MaxRight_NeedleValue)
            {
                RightActualNeedleValue -= Time.deltaTime * m_EngineData.m_RightNeedleVelocity;
                float l_TrailValue = RightActualNeedleValue / m_EngineData.m_RightTrailArc;
                OnAccOnRight?.Invoke(new Vector3(0, 0, RightActualNeedleValue), l_TrailValue);
                CalculateSpeed();
            }
        }
        private void ManageLeftNeedle_Up()
        {
            if (LeftActualNeedleValue > m_EngineData.m_MaxLeft_NeedleValue)
            {
                LeftActualNeedleValue -= Time.deltaTime * m_EngineData.m_LeftNeedleVelocity;
                float l_TrailValue = LeftActualNeedleValue / m_EngineData.m_MaxLeft_NeedleValue;
                OnAccOnLeft?.Invoke(new Vector3(0, 0, LeftActualNeedleValue), l_TrailValue);
            }
        }
        private void ManageRightNeedle_Down() 
        {
            if (RightActualNeedleValue < m_EngineData.m_MinRight_NeedleValue)
            {
                RightActualNeedleValue += Time.deltaTime * m_EngineData.m_RightNeedleVelocity;
                float l_TrailValue = RightActualNeedleValue / m_EngineData.m_RightTrailArc;
                OnAccOnRight?.Invoke(new Vector3(0, 0, RightActualNeedleValue), l_TrailValue);
                CalculateSpeed();
            }
        }
        private void ManageLeftNeedle_Down() 
        {
            if (LeftActualNeedleValue < m_EngineData.m_MinLeft_NeedleValue)
            {
                LeftActualNeedleValue += Time.deltaTime * m_EngineData.m_LeftNeedleVelocity;
                float l_TrailValue = LeftActualNeedleValue / m_EngineData.m_MaxLeft_NeedleValue;
                OnAccOnLeft?.Invoke(new Vector3(0, 0, LeftActualNeedleValue), l_TrailValue);
            }
        }
        #endregion
        #region SPEED CONTROLLER
        /// <summary>
        /// Calculates speed and promts OnSpeedChange event.
        /// </summary>
        private void CalculateSpeed()
        {
            //Since speed sphere doesn't have all segments equal:
            //from 0 to 60 segments are 5km/h
            //from 60 to 180 segments are 10km/h
            //from 180 to 300 segments are also 10km/h but with different total angle.
            //So i've decided to calculate each angle segment sepparately in order to provide an accurate translation from angles to actual velocity:
            float l_Speed = 0f;
            float l_ActualAngle = Math.Abs(RightActualNeedleValue);
            if(l_ActualAngle <= 90)
            {
                //We make a rule of 3 taking into account the total velocity in the arc and the total angle en each arc, for example:
                //From 0 km/h to 60km/h we have 90degrees and 60km/h in total:
                l_Speed = (l_ActualAngle * 60) / 90;                
            }
            else if(l_ActualAngle <= 198)
            {
                l_ActualAngle -= 90;
                l_Speed = (l_ActualAngle * 120) / 108;
                l_Speed += 60;

            }
            else if(l_ActualAngle > 198)
            {
                l_ActualAngle -= 198;
                l_Speed = (l_ActualAngle * 120) / 72;
                l_Speed += 180;
            }
            OnSpeedChange?.Invoke((int)l_Speed);
        }
        #endregion
    }
}
