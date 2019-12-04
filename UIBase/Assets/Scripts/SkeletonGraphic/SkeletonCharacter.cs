using UnityEngine;
using System.Collections;
using Spine.Unity;

public class SkeletonCharacter : MonoBehaviour
{
    public SkeletonMecanim character;
    public Animator animator;
    public SkeletonDataAsset asset;
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
        Item item = DIContainer.GetModule<IItemManager>().GetEquipmentWeapon();
        //character.SKELETON.();
        string skin = "default";
        Debug.Log(item);
        if (item != null)
        {
            skin = ((WeaponType.Type)item.id).ToString() + (item.levelUpgrade + 1).ToString();
            animator.Play(((WeaponType.Type)item.id).ToString());
        }
        else
        {
            animator.SetTrigger("default");
        }
        character.skeleton.SetSkin(skin);
        character.skeleton.SetSlotsToSetupPose();
    }
}
