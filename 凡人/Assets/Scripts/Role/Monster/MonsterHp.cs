using System;
using UnityEngine;


public class MonsterHp : MonoBehaviour
{
    private const float LIFE_TIME = 1f;

    public Transform HpTarget;

    public GameObject HPGUI;

    public Role monster;

    public bool bBack = true;

    private float LifeLeft = 1f;

    private void Start()
	{
		this.HpTarget = this.monster.GetTrans();
		this.HPGUI = base.gameObject;
		this.HPGUI.SetActive(false);
	}

	private void Update()
	{
		if (this.monster == null || this.monster.IsDead())
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		this.HPGUI.active = true;
		if (this.HpTarget == null)
		{
			if (this.HPGUI != null)
			{
				UnityEngine.Object.Destroy(this.HPGUI);
			}
			return;
		}
		if (this.HPGUI == null)
		{
			return;
		}
		this.LifeLeft -= GameTime.deltaTime;
		if (this.LifeLeft <= 0f)
		{
			this.HPGUI.active = false;
			return;
		}
		float num = 1f;
		Transform transform = Camera.main.transform;
		if (!this.bBack)
		{
			float num2 = (float)this.monster.GetCurHp();
			float num3 = (float)this.monster.GetMaxHp();
			num = num2 / num3;
		}
		if (transform.InverseTransformPoint(this.HpTarget.position).z > 0f)
		{
			Monster monster = this.monster as Monster;
			Vector3 position = Camera.main.WorldToViewportPoint(this.HpTarget.position + Vector3.up * monster.HpHigh());
			float num4 = 100f * num;
			if (num4 >= 0f)
			{
				//this.HPGUI.guiTexture.pixelInset = new Rect(-50f, 0f, 100f * num, 10f);
			}
			else
			{
				//this.HPGUI.guiTexture.pixelInset = new Rect(-50f, 0f, 0f, 10f);
			}
			if (this.bBack)
			{
				this.HPGUI.transform.position = new Vector3(position.x, position.y, position.z - 10f);
			}
			else
			{
				this.HPGUI.transform.position = position;
			}
		}
	}

	public void ShowHP()
	{
		base.gameObject.SetActive(true);
		this.LifeLeft = 1f;
	}
}
