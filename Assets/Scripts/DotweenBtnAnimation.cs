using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DotweenBtnAnimation : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        if (_button != null)
        {
            _button.onClick.AddListener(AnimateButtonPress);
        }
    }

    private void AnimateButtonPress()
    {
        transform.DOScale(0.9f, 0.2f).SetEase(Ease.OutQuad).OnComplete(ResetButtonScale);
    }

    private void ResetButtonScale()
    {
        transform.DOScale(1f, 0.1f).SetEase(Ease.InQuad);
    }
}