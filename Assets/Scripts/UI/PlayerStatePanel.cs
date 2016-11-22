using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class PlayerStatePanel : PanelControlScript
{
    private PlayerState _playerModel;
    public Text _healthLabel;
    public Text _staminaLabel;

    public override void Init(Object model)
    {
        _playerModel = (PlayerState)model;
    }

    void Update()
    {
        _healthLabel.text = _playerModel.Health.ToString();
        _staminaLabel.text = _playerModel.Stamina.ToString();
    }
}
