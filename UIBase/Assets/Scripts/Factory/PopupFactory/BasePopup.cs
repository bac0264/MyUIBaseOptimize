using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BasePopup : MonoBehaviour
{
    public enum TypeOfPopup
    {
        PO_ItemTooltip,
        PO_ForgingUpgrade,
        PO_Character,
    }
    public TypeOfPopup type;
    public virtual void ShowPopup()
    {
        gameObject.SetActive(true);
    }
    public virtual void HidePopup()
    {
        gameObject.SetActive(false);
    }
}
