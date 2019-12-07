using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000383 RID: 899
public class TimeOutManager : MonoBehaviour
{
	// Token: 0x17000278 RID: 632
	// (get) Token: 0x0600167F RID: 5759 RVA: 0x000B00C8 File Offset: 0x000AE2C8
	public static GameObject Target
	{
		get
		{
			TimeOutManager.target = GameObject.Find(TimeOutManager.ClassName);
			if (TimeOutManager.target == null)
			{
				TimeOutManager.target = new GameObject(TimeOutManager.ClassName);
			}
			return TimeOutManager.target;
		}
	}

	// Token: 0x06001680 RID: 5760 RVA: 0x000B0100 File Offset: 0x000AE300
	private void OnDisable()
	{
		if (base.gameObject != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001681 RID: 5761 RVA: 0x000B0120 File Offset: 0x000AE320
	public static void AddTimeOut(TimeOutManager target)
	{
		if (!TimeOutManager.toms.Contains(target))
		{
			TimeOutManager.toms.Add(target);
		}
	}

	// Token: 0x06001682 RID: 5762 RVA: 0x000B0140 File Offset: 0x000AE340
	public static TimeOutManager SetTimeOut(Transform target, float waitTime, Callback callBack)
	{
		if (target == null)
		{
			target = TimeOutManager.Target.transform;
		}
		//TimeOutManager timeOutManager = Static_Utils.newScriptedGO<TimeOutManager>(target);
		//TimeOutManager.AddTimeOut(timeOutManager);
		//timeOutManager.CallLater(timeOutManager, callBack, waitTime);
		//return timeOutManager;
        return null;
    }

	// Token: 0x06001683 RID: 5763 RVA: 0x000B017C File Offset: 0x000AE37C
	public static void ClearAllTiemOut()
	{
		foreach (TimeOutManager timeOutManager in TimeOutManager.toms)
		{
			if (timeOutManager != null)
			{
				timeOutManager.ClearTimeOut();
			}
		}
		TimeOutManager.toms.Clear();
		UnityEngine.Object.Destroy(TimeOutManager.target);
	}

	// Token: 0x06001684 RID: 5764 RVA: 0x000B0200 File Offset: 0x000AE400
	public void ClearTimeOut()
	{
		base.StopAllCoroutines();
		if (base.gameObject != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001685 RID: 5765 RVA: 0x000B0230 File Offset: 0x000AE430
	private void CallLater(TimeOutManager timeOut, Callback callBack, float waitTime)
	{
		if (base.gameObject.active)
		{
			base.StartCoroutine(this.CallFunction(timeOut, callBack, waitTime));
		}
	}

	// Token: 0x06001686 RID: 5766 RVA: 0x000B0260 File Offset: 0x000AE460
	private IEnumerator CallFunction(TimeOutManager timeOut, Callback callBack, float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		if (timeOut != null && timeOut.gameObject != null)
		{
			callBack();
			UnityEngine.Object.DestroyImmediate(timeOut.gameObject);
		}
		yield break;
	}

	// Token: 0x06001687 RID: 5767 RVA: 0x000B02A0 File Offset: 0x000AE4A0
	public static TimeOutManager SetTimeOut<T>(Transform target, float waitTime, Callback<T> callBack, T arg1)
	{
		if (target == null)
		{
			target = TimeOutManager.Target.transform;
		}
        //TimeOutManager timeOutManager = Static_Utils.newScriptedGO<TimeOutManager>(target);
        //TimeOutManager.AddTimeOut(timeOutManager);
        //timeOutManager.CallLater<T>(timeOutManager, waitTime, callBack, arg1);
        //return timeOutManager;
        return null;
    }

	// Token: 0x06001688 RID: 5768 RVA: 0x000B02E0 File Offset: 0x000AE4E0
	private void CallLater<T>(TimeOutManager timeOut, float waitTime, Callback<T> callBack, T arg1)
	{
		base.StartCoroutine(this.CallFunction<T>(timeOut, waitTime, callBack, arg1));
	}

	// Token: 0x06001689 RID: 5769 RVA: 0x000B0304 File Offset: 0x000AE504
	private IEnumerator CallFunction<T>(TimeOutManager timeOut, float waitTime, Callback<T> callBack, T arg1)
	{
		yield return new WaitForSeconds(waitTime);
		if (timeOut != null && timeOut.gameObject != null)
		{
			callBack(arg1);
			UnityEngine.Object.DestroyImmediate(timeOut.gameObject);
		}
		yield break;
	}

	// Token: 0x0600168A RID: 5770 RVA: 0x000B0354 File Offset: 0x000AE554
	public static TimeOutManager SetTimeOut<T, U>(Transform target, float waitTime, Callback<T, U> callBack, T arg1, U arg2)
	{
		if (target == null)
		{
			target = TimeOutManager.Target.transform;
		}
        //TimeOutManager timeOutManager = Static_Utils.newScriptedGO<TimeOutManager>(target);
        //TimeOutManager.AddTimeOut(timeOutManager);
        //timeOutManager.CallLater<T, U>(timeOutManager, waitTime, callBack, arg1, arg2);
        //return timeOutManager;
        return null;

    }

	// Token: 0x0600168B RID: 5771 RVA: 0x000B0398 File Offset: 0x000AE598
	private void CallLater<T, U>(TimeOutManager timeOut, float waitTime, Callback<T, U> callBack, T arg1, U arg2)
	{
		base.StartCoroutine(this.CallFunction<T, U>(timeOut, waitTime, callBack, arg1, arg2));
	}

	// Token: 0x0600168C RID: 5772 RVA: 0x000B03BC File Offset: 0x000AE5BC
	private IEnumerator CallFunction<T, U>(TimeOutManager timeOut, float waitTime, Callback<T, U> callBack, T arg1, U arg2)
	{
		yield return new WaitForSeconds(waitTime);
		if (timeOut != null && timeOut.gameObject != null)
		{
			callBack(arg1, arg2);
			UnityEngine.Object.DestroyImmediate(timeOut.gameObject);
		}
		yield break;
	}

	// Token: 0x0600168D RID: 5773 RVA: 0x000B041C File Offset: 0x000AE61C
	public static TimeOutManager SetTimeOut<T, U, V>(Transform target, float waitTime, Callback<T, U, V> callBack, T arg1, U arg2, V arg3)
	{
		if (target == null)
		{
			target = TimeOutManager.Target.transform;
		}
		//TimeOutManager timeOutManager = Static_Utils.newScriptedGO<TimeOutManager>(target);
		//TimeOutManager.AddTimeOut(timeOutManager);
		//timeOutManager.CallLater<T, U, V>(timeOutManager, waitTime, callBack, arg1, arg2, arg3);
		//return timeOutManager;

        return null;
    }

	// Token: 0x0600168E RID: 5774 RVA: 0x000B0460 File Offset: 0x000AE660
	private void CallLater<T, U, V>(TimeOutManager timeOut, float waitTime, Callback<T, U, V> callBack, T arg1, U arg2, V arg3)
	{
		base.StartCoroutine(this.CallFunction<T, U, V>(timeOut, waitTime, callBack, arg1, arg2, arg3));
	}

	// Token: 0x0600168F RID: 5775 RVA: 0x000B0488 File Offset: 0x000AE688
	private IEnumerator CallFunction<T, U, V>(TimeOutManager timeOut, float waitTime, Callback<T, U, V> callBack, T arg1, U arg2, V arg3)
	{
		yield return new WaitForSeconds(waitTime);
		if (timeOut != null && timeOut.gameObject != null)
		{
			callBack(arg1, arg2, arg3);
			UnityEngine.Object.DestroyImmediate(timeOut.gameObject);
		}
		yield break;
	}

	// Token: 0x04001686 RID: 5766
	public static string ClassName = "TimeOutManager";

	// Token: 0x04001687 RID: 5767
	public static List<TimeOutManager> toms = new List<TimeOutManager>();

	// Token: 0x04001688 RID: 5768
	private static GameObject target = null;
}
