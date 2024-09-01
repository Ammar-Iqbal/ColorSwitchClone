using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text starCountText;

    private void Start()
    {
        GameManager.Instance.OnStarsChanged += UpdateStarCount;
        UpdateStarCount(0);
    }

    private void UpdateStarCount(int newStarCount)
    {
        starCountText.text = newStarCount.ToString();
    }
}