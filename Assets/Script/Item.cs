using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator m_Animator;
    [SerializeField] private string m_SelectBool;

    public void Select(bool value)
    {
        m_Animator.SetBool(m_SelectBool, value);
    }

}
