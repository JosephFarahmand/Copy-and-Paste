using System;
using UnityEngine;

public class Operator : MonoBehaviour
{
    [SerializeField] private Key m_Ctrl;
    [SerializeField] private Key m_Key;

    private bool m_HoldCtrl;
    private bool m_HoldKey;

    public event Action OnCallback;

    private void OnEnable()
    {
        m_Ctrl.OnHold += HoldCtrl;
        m_Key.OnHold += HoldKey;

        m_Key.OnPress += Press;
    }

    private void OnDisable()
    {
        m_Ctrl.OnHold -= HoldCtrl;
        m_Key.OnHold -= HoldKey;

        m_Key.OnPress -= Press;
    }

    private void HoldCtrl(bool value)
    {
        m_HoldCtrl = value;
    }

    private void HoldKey(bool value)
    {
        m_HoldKey = value;
    }

    private void Press()
    {
        if (m_HoldCtrl && m_HoldKey)
        {
            OnCallback?.Invoke();
        }
    }
}