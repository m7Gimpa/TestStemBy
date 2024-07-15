using UnityEngine;
using UnityEngine.UI;

public class MainUIButtons : MonoBehaviour
{
    [SerializeField] private Button shootButton;
    [SerializeField] private Button pistolButton;
    [SerializeField] private Button shotgunButton;

    [SerializeField] private HeroPlayer _player;

    private void Start()
    {
        shootButton.onClick.AddListener(() => _player.Shoot());
        pistolButton.onClick.AddListener(() => _player.SwitchToPistol());
        shotgunButton.onClick.AddListener(() => _player.SwitchToShotGun());
    }
}