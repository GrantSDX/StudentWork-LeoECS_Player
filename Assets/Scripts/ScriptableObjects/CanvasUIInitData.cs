using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CanvasUIInitData", menuName = "ScriptableObject/CanvasUIInitData", order = 0)]
    public class CanvasUIInitData : ScriptableObject
    {

        [SerializeField] private GameObject canvasPrefab;

        public GameObject CanvasPrefab => canvasPrefab;
    }
}