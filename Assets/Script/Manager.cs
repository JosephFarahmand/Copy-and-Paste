using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [Header("")]
    [SerializeField] private Item m_Refrence;
    private Transform m_SpawnPoint;

    [Header("Operators")]
    [SerializeField] private Operator Copy;
    [SerializeField] private Operator Pase;

    private void Start()
    {
        m_SpawnPoint = m_Refrence.transform;
    }

    private void OnEnable()
    {
        Copy.OnCallback += CopyAction;
        Pase.OnCallback += PaseAction;
    }

    private void OnDisable()
    {
        Copy.OnCallback -= CopyAction;
        Pase.OnCallback -= PaseAction;
    }

    private void PaseAction()
    {
        m_Refrence.Select(false);

        var ins =  Instantiate(m_Refrence, m_SpawnPoint.position, UnityEngine.Random.rotation);

        ins.GetOrAddComponent<Rigidbody>().AddForce(ins.transform.forward * UnityEngine.Random.Range(2, 5), ForceMode.Impulse);

        m_SpawnPoint = ins.transform;

        m_Refrence = ins;
    }

    private void CopyAction()
    {
        m_Refrence.Select(true);
    }
}
