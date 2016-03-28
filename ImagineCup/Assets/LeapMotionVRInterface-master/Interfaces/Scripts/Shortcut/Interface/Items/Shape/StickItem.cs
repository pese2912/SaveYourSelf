﻿using UnityEngine;
using System.Collections;

public class StickItem : ShapeItem {
	
	private GameObject rendererObj;
	private GameObject backgroundObj;
	private GameObject focusingObj;
	private GameObject selectingObj;
	private GameObject labelObj;
	private GameObject centerObj;
	
	private UIStickItem _uiStickItemBg;
	private UIStickItem _uiStickItemFs; 
	private UIStickItem _uiStickItemSt;
	
	
	private float _width;
	private float _height;
	private float _amount;
	
	
	private float _selectProg = 0.0f;
	private float _selectSpeed = 1.0f;
	private bool _isSelected = false;

	private StickShortcutDirection _direction;
	
	public override void Build (ShortcutSettings sSettings, GameObject parentObj)
	{
		base.Build (sSettings, parentObj);
		
		_selectSpeed = _sSettings.SelectSpeed;

		_width = _sSettings.ItemWidth;
		_height = _sSettings.ItemHeight;

		_direction = sSettings.Direction;

		// rendering
		Rendering ();
		
		// interaction setting
		InteractionManager.SetItemPos (_id, Camera.main.WorldToViewportPoint (centerObj.transform.position));
		InteractionManager.SetInterStart (_id, _sSettings.FocusStart);
	}
	
	
	// Update is called once per frame
	void Update () {
		if (_curLayer != null) {
			if (InteractionManager.HasItemId (_id)) {
				if (_curLayer.UILayer.IsCurrentLayer) {
					// register this item pos to interaction manager
					InteractionManager.SetItemPos (_id, Camera.main.WorldToViewportPoint(centerObj.transform.position));

					float deltaSelectSpeed = _selectSpeed*Time.deltaTime;
					/***** focus, select ui update *****/
					float progress = InteractionManager.GetItemHighlightProgress (_id);

					// set now progress
					InteractionManager.SetItemProg(_id, progress);

					float focusStart = _sSettings.FocusStart;; // trigger focus percent = 80%
					if (progress > focusStart && !_curLayer.UILayer.IsAnimating) { // is focusing
						float focusProg = Mathf.Lerp (0, 1, progress - focusStart);

						// focus, select event process
						if (focusProg == 1 && _isNearestItem) {// all focus, is selecting
							if (_selectProg < 1.0f) {
								_selectProg += deltaSelectSpeed;
							}

							// item click evnet
							if (_selectProg >= 1.0f) {
								_selectProg = 1.0f;

								if (_execType == ActionExecType.Once) {
									if (!_isSelected) { // select action is triggered just once
										_isSelected = true;
										_selectableItem.SelectAction();
									}
								} else if (_execType == ActionExecType.DuringSelecting) {
									_selectableItem.SelectAction();
								}
							}
							// select up update
							if (_direction == StickShortcutDirection.Horizontal) {
								_uiStickItemBg.UpdateMesh (_width, _height, 1.0f, 1.0f, _backgroundColor);
								_uiStickItemFs.UpdateMesh (_width, _height, 0.0f, _selectProg, _focusingColor);
								_uiStickItemSt.UpdateMesh (_width, (_height*_selectProg), 0.0f, 0.0f, _selectingColor);
							} else if (_direction == StickShortcutDirection.Vertical) {
								_uiStickItemBg.UpdateMesh (_width, _height, 1.0f, 1.0f, _backgroundColor);
								_uiStickItemFs.UpdateMesh (_width, _height, _selectProg, 0.0f, _focusingColor);
								_uiStickItemSt.UpdateMesh ((_width*_selectProg), _height, 0.0f, 0.0f, _selectingColor);
							}

						}
						else {
							_selectProg = 0.0f;
							_isSelected = false;
							if (_isNearestItem) {
								_selectProg = 0.05f;
								if (_direction == StickShortcutDirection.Horizontal) {
									_uiStickItemBg.UpdateMesh (_width, _height, 0.0f, focusProg, _backgroundColor);
									_uiStickItemFs.UpdateMesh (_width, (_height*focusProg), 0.0f, (0.05f/focusProg), _focusingColor);
									_uiStickItemSt.UpdateMesh (_width, _height*0.05f, 0.0f, 0.0f, _selectingColor);
								} else if (_direction == StickShortcutDirection.Vertical) {
									_uiStickItemBg.UpdateMesh (_width, _height, focusProg, 0.0f, _backgroundColor);
									_uiStickItemFs.UpdateMesh ((_width*focusProg), _height, (0.05f/focusProg), 0.0f, _focusingColor);
									_uiStickItemSt.UpdateMesh (_width*0.05f, _height, 0.0f, 0.0f, _selectingColor);
								}


							} else {
								// focus ui update
								if (_direction == StickShortcutDirection.Horizontal) {
									_uiStickItemBg.UpdateMesh (_width, _height, 0.0f, focusProg, _backgroundColor);
									_uiStickItemFs.UpdateMesh (_width, (_height*focusProg), 0.0f, 0.0f, _focusingColor);
									_uiStickItemSt.UpdateMesh (_width, _height, 1.0f, 1.0f, _selectingColor);
								} else if (_direction == StickShortcutDirection.Vertical) {
									_uiStickItemBg.UpdateMesh (_width, _height, focusProg, 0.0f, _backgroundColor);
									_uiStickItemFs.UpdateMesh ((_width*focusProg), _height, 0.0f, 0.0f, _focusingColor);
									_uiStickItemSt.UpdateMesh (_width, _height, 1.0f, 1.0f, _selectingColor);
								}

							}

						}
					}
					else { // is non focusing
						// general ui update
						_uiStickItemBg.UpdateMesh (_width, _height, 0.0f, 0.0f, _backgroundColor);
						_uiStickItemFs.UpdateMesh (_width, _height, 1.0f, 1.0f, _focusingColor);
						_uiStickItemSt.UpdateMesh (_width, _height, 1.0f, 1.0f, _selectingColor);

					}
					/****************************************/
				}
				else {
					// register this item pos to interaction manager
					InteractionManager.SetItemPos (_id, Vector3.one*999);

				}
			}
		}
	}
	
	
	public override void Rendering() {
		/***** rendering *****/
		// make renderer gameobject
		rendererObj = new GameObject ("Renderer");
		rendererObj.transform.SetParent (_parentObj.transform, false);

		// center pivot position setting
		centerObj = new GameObject("Center");
		centerObj.transform.SetParent (rendererObj.transform, false);
		centerObj.transform.localPosition = new Vector3 (_width/2, _height/2, 0);
		
		// build arc item background ui
		backgroundObj = new GameObject ("Background");
		backgroundObj.transform.SetParent (rendererObj.transform, false);
		focusingObj = new GameObject ("Focusing");
		focusingObj.transform.SetParent (rendererObj.transform, false);
		selectingObj = new GameObject ("Selecting");
		selectingObj.transform.SetParent (rendererObj.transform, false);

		_uiStickItemBg = backgroundObj.AddComponent<UIStickItem> ();
		_uiStickItemBg.Build (_sSettings);
		_uiStickItemBg.UpdateMesh (_width, _height, 0.0f, 0.0f, _backgroundColor);

		_uiStickItemFs = focusingObj.AddComponent<UIStickItem> ();
		_uiStickItemFs.Build (_sSettings);
		
		_uiStickItemSt = selectingObj.AddComponent<UIStickItem> ();
		_uiStickItemSt.Build (_sSettings);

		// build item label ui
		labelObj = new GameObject ("Label");
		labelObj.transform.SetParent (rendererObj.transform, false);
		labelObj.transform.localPosition = new Vector3(_sSettings.ItemWidth/2-0.1f, _sSettings.ItemHeight/2, 0);
		labelObj.transform.localRotation = Quaternion.FromToRotation(Vector3.back, Vector3.down);
		labelObj.transform.localScale = new Vector3(1, 1, 1);

		UIItemLabel _uiItemLabel = labelObj.AddComponent<UIItemLabel>();
		_uiItemLabel.SetAttributes (_label, _sSettings.TextFont, _sSettings.TextSize, _sSettings.TextColor, (_sSettings.ItemWidth-0.2f)*500.0f);
		_uiItemLabel.SetTextAlignment (_textAlignment);

		// rotate text for easy read
		if (_textRotation == TextRotationType.Left) {
			_uiItemLabel.RotateText(new Vector3(0.0f, 0.0f, 90.0f));
		} else if (_textRotation == TextRotationType.Upsidedown) {
			_uiItemLabel.RotateText(new Vector3(0.0f, 0.0f, 180.0f));
		} else if (_textRotation == TextRotationType.Right) {
			_uiItemLabel.RotateText(new Vector3(0.0f, 0.0f, -90.0f));
		} 

		// each types ui
		switch (_itemType) {
		case (ItemType.Parent) :
			GameObject labelHasChildObj = new GameObject ("HasChildArrow");
			labelHasChildObj.transform.SetParent (rendererObj.transform, false);
			if (_direction == StickShortcutDirection.Horizontal) {
				labelHasChildObj.transform.localPosition = new Vector3(_sSettings.ItemWidth/2, _sSettings.ItemHeight*0.9f, 0);
				labelHasChildObj.transform.localRotation = Quaternion.FromToRotation(Vector3.down, Vector3.forward);
				labelHasChildObj.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

			} else if (_direction == StickShortcutDirection.Vertical) {
				labelHasChildObj.transform.localPosition = new Vector3(_sSettings.ItemWidth*0.9f, _sSettings.ItemHeight/2, 0);
				labelHasChildObj.transform.localRotation = Quaternion.FromToRotation(Vector3.down, Vector3.forward);
				labelHasChildObj.transform.localScale = new Vector3(1, 1, 1);
			}

			UIHasChild uiLabelHasChild = labelHasChildObj.AddComponent<UIHasChild>();
			uiLabelHasChild.SetAttributes ((_direction == StickShortcutDirection.Horizontal)?"▲":"▶", _sSettings.TextFont, _sSettings.TextSize, _sSettings.TextColor);
			
			break;
		case (ItemType.NormalButton) :
			
			break;
		default :
			break;
		}


	}
}
