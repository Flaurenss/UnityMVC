using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "NeedleData", menuName = "ScriptableObjects/NeedleData", order = 1)]
    public class DataContainerSO : ScriptableObject
    {
        [Header("Needle values")]
        public float m_MinRight_NeedleValue;
        public float m_MinLeft_NeedleValue;
        public float m_MaxRight_NeedleValue;
        public float m_MaxLeft_NeedleValue;
        [Space(10)]
        [Header("NeedlesVelocity")]
        public float m_RightNeedleVelocity;
        public float m_LeftNeedleVelocity;
        [Space(10)]
        [Header("TrailValues")]
        public float m_RightTrailArc;
        public float m_LeftTrailArc;
    }
}
