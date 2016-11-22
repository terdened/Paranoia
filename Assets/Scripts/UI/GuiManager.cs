using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuiManager : MonoBehaviour {
    private List<PanelControlScript> _panels;

	// Use this for initialization
	void Start () {
        _panels = new List<PanelControlScript>();

        var playerState = GetComponent<PlayerState>();
        var playerStatePanel = GetComponent<PlayerStatePanel>();
        playerStatePanel.Init(playerState);
        _panels.Add(playerStatePanel);
    }
}
