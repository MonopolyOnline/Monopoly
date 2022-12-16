using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ArrayTexturSector : MonoBehaviour
{
    [SerializeField] private Material[] sectors = new Material[52];
    private void Start()
    {
        GetComponent<MeshRenderer>().materials = sectors;
    }
}
