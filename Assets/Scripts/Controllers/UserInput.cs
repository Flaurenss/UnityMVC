using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EDAG.Controllers
{
    public class UserInput : MonoBehaviour
    {
        [SerializeField]
        private KeyCode m_AccKey = KeyCode.A;
        private PanelController m_PanelController;
        public void Configure(PanelController _panelController)
        {
            m_PanelController = _panelController;
        }
        void Update()
        {
            if(Input.GetKey(m_AccKey))
            {
                m_PanelController.AccelOn();
            }
            else
            {
                m_PanelController.AccelOff();
            }
        }
    }
}

