using System;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

public class UIDialogForm : UIFormBase
{
    public Text NameText;

    public Text ContentText;

 //   private CommonSettings.VoidCallBack _callback;

 //   private float _timeCount;

 //   public void Show(string roleKey, string msg, CommonSettings.VoidCallBack callback = null)
	//{
	//	this._callback = callback;
	//	this.Show(new StoryAction
	//	{
	//		type = "DIALOG",
	//		value = roleKey + "#" + msg
	//	}, null);
	//}

	//public void Show(StoryAction action, CommonSettings.VoidCallBack callback = null)
	//{
	//	this._callback = callback;
	//	this._timeCount = 0f;
	//	base.gameObject.SetActive(true);
 //       string[] array = action.value.Split(new char[]
 //       {
 //           '#'
 //       });
 //       string roleKey = array[0];
 //       string text = array[1];
 //       NameText.text = roleKey;
 //       //text = text.Replace("$MALE$", RuntimeData.Instance.maleName).Replace("$FEMALE$", RuntimeData.Instance.femaleName).Replace("$ZHENLONG_LEVEL$", (GlobalData.ZhenlongqijuLevel + 1).ToString());
 //       //text = text.Replace("[[red:", "<color='red'>").Replace("[[yellow:", "<color='yellow'>").Replace("]]", "</color>");
 //       ContentText.text = text;
 //       //base.transform.FindChild("_mask").FindChild("HeadImage").GetComponent<Image>().sprite = Resource.GetImage(CommonSettings.getRoleHead(roleKey), false);
 //   }

	//public void OnClicked()
	//{
	//	base.gameObject.SetActive(false);
	//	RuntimeData.Instance.mapUI.ExecuteNextStoryAction(this._callback);
	//}

	//public void OnJump()
	//{
	//	base.gameObject.SetActive(false);
	//	RuntimeData.Instance.mapUI.JumpDialogs(this._callback);
	//}

	//private void Start()
	//{
	//}

	//private void Update()
	//{
	//	if (Input.GetKey(KeyCode.Space))
	//	{
	//		this._timeCount += Time.deltaTime;
	//		if (this._timeCount > 0.3f)
	//		{
	//			this.OnClicked();
	//		}
	//	}
	//	else if (Input.GetKeyUp(KeyCode.Space))
	//	{
	//		this.OnClicked();
	//	}
	//	else if (Input.GetMouseButtonDown(0))
	//	{
	//		this.OnClicked();
	//	}
	//}
}
