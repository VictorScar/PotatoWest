using System.Collections;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;

public class TestView : MonoBehaviour
{
   [SerializeReference, SerializeField] private TestViewAnimator _testViewAnimator;
   [SerializeField] private CanvasGroup cg;
}
