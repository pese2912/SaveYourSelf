﻿using UnityEngine;
using System.Collections;

public abstract class ItemLayer : MonoBehaviour, IItemLayer {
	
	protected string _layerName = "";
	protected string _cancelItemLabel = "";
	
	protected bool _appearAnimFlag = false;
	
	protected ShortcutSettings _sSettings;
	protected GameObject _parentObj;
	
	protected GameObject _uiLayerObj;
	protected UILayer _uiLayer;
	protected int _curLevel = 1;
	protected ShortcutItemLayer _prevLayer = null;
	protected int _prevLevel = 0;
	
	protected ShortcutItem[] items;

	public string CancelItemLabel { get { return _cancelItemLabel; } set { _cancelItemLabel = value; } }
	public string LayerName { get { return _layerName; } set { _layerName = value; } }

	// interface implementation
	public int Level { get { return _curLevel; } set { _curLevel = value; } }
	public UILayer UILayer { get { return _uiLayer; } set {	_uiLayer = value; } }
    public ShortcutItemLayer PrevLayer {
        get { return _prevLayer; }
		set {
			_prevLayer = value;
			_prevLevel = ((_prevLayer == null)? 0 : _prevLayer.Level);
		}
	}

	public void Build(ShortcutSettings sSettings, GameObject parentObj) {
		_sSettings = sSettings;
		_parentObj = parentObj;

		items = Getter.GetChildItemsFromGameObject (gameObject);

		BuildItems ();
	}

	protected virtual void BuildItems() {
		_uiLayerObj = new GameObject ("UILayer_" + _layerName);
		_uiLayerObj.transform.SetParent (_parentObj.transform, false);
		_uiLayer = _uiLayerObj.AddComponent<UILayer> ();
		_uiLayer.Build (_sSettings);
		_uiLayer.AppearLayer(_curLevel-_prevLevel);

	}

	// select nearest item;
	void Update() {
		if (items != null && _uiLayer != null) {
			if (_uiLayer.IsCurrentLayer) {
				int nearestItemIdx = 0;
				float nearestProg = 0.0f;

				// find nearest item
				for (int i=0; i<items.Length; i++) {
					int itemId = items[i].Id;
					float prog = InteractionManager.GetItemProg(itemId);
					
					if (prog > nearestProg) {
						nearestProg = prog;
						nearestItemIdx = i;
					}
				}

				// signal to item
				for (int i=0; i<items.Length; i++) {
					if (i == nearestItemIdx) {
						items[i].Item.IsNearestItem = true;
					} else {
						items[i].Item.IsNearestItem = false;
					}
				}

			}
		} 
	}
	
}
