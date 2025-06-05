using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buttons;

    public Animator animator;
    public AnimatorOverrideController[] skinOverride;
    public int SkinIndex;

    public void SelectButton()
    {
        animator.runtimeAnimatorController = skinOverride[SkinIndex];

    }
}
