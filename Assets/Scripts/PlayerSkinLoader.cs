using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinLoader : MonoBehaviour
{
    public Animator animator;

    public AnimatorOverrideController greenSkin;
    public AnimatorOverrideController pinkSkin;
    public AnimatorOverrideController blueSkin;

    void Start()
    {
        string skin = PlayerPrefs.GetString("SelectedSkin", "Green"); // за замовчуванням зелений

        switch (skin)
        {
            case "Pink":
                animator.runtimeAnimatorController = pinkSkin;
                break;
            case "Blue":
                animator.runtimeAnimatorController = blueSkin;
                break;
            default:
                animator.runtimeAnimatorController = greenSkin;
                break;
        }
    }
}
