using Assets.Scripts.Data;
using EDAG.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Injector
{
    public class MainInjector: MonoBehaviour
    {
        [SerializeField]
        private UserInput m_UserInput;
        [SerializeField]
        private DataContainerSO m_EngineData;
        private void Awake()
        {
            m_UserInput?.Configure(new PanelController(m_EngineData));
        }
    }
}
