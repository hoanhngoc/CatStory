using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    // vi tri tele

    public Transform GetDestiantion()
    {
        return destination;
    }
}
