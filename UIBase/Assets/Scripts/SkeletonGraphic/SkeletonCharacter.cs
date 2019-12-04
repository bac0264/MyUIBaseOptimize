using UnityEngine;
using System.Collections;
using Spine.Unity;

public class SkeletonCharacter : MonoBehaviour
{
    public SkeletonMecanim character;
    public Animator animator;
    private void Start()
    {
        RefreshUI();
    }
    private void OnValidate()
    {
        if (character == null) character = GetComponent<SkeletonMecanim>();
        if (animator == null) animator = GetComponent<Animator>();
    }
    public void RefreshUI()
    {
        if (character != null && character.skeleton != null)
        {
            Item item = DIContainer.GetModule<IItemManager>().GetEquipmentWeapon();
            //character.SKELETON.();
            if (item != null)
            {
                string skin = ((WeaponType.Type)item.id).ToString() + (item.levelUpgrade + 1).ToString();
                animator.Play(((WeaponType.Type)item.id).ToString());
                character.skeleton.SetSkin(skin);
                character.skeleton.SetSlotsToSetupPose();
            }
            else
            {
                string skin = "default";
                animator.Play("animation");
                character.skeleton.SetSkin(skin);
                character.skeleton.SetSlotsToSetupPose();
            }
        }
    }
}
