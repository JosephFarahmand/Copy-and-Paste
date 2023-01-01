using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyCode m_Key;

    [Header("Animation")]
    [SerializeField] private Animator m_Animator;
    [SerializeField] private string m_PressBool;

    public event Action<bool> OnHold;
    public event Action OnPress;

    void Update()
    {
        OnHold?.Invoke(Input.GetKey(m_Key));

        if (Input.GetKeyDown(m_Key))
        {
            m_Animator.SetBool(m_PressBool, true);
            OnPress?.Invoke();

        }
        else if (Input.GetKeyUp(m_Key))
        {
            m_Animator.SetBool(m_PressBool, false);
        }
    }
}
