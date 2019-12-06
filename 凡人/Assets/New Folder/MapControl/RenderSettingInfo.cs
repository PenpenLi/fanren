using System;
using UnityEngine;

public class RenderSettingInfo
{
    public int mapID;

    public Color ambientLight;

    public float flareStrength;

    public bool fog;

    public Color fogColor;

    public float fogDensity;

    public float fogEndDistance;

    public FogMode fogMode;

    public float fogStartDistance;

    public float haloStrength;

    public string skyboxMatStr;

    public void SetRenderSettings()
	{
		RenderSettings.ambientLight = this.ambientLight;
		RenderSettings.flareStrength = this.flareStrength;
		RenderSettings.fog = this.fog;
		RenderSettings.fogColor = this.fogColor;
		RenderSettings.fogDensity = this.fogDensity;
		RenderSettings.fogEndDistance = this.fogEndDistance;
		RenderSettings.fogMode = this.fogMode;
		RenderSettings.fogStartDistance = this.fogStartDistance;
		RenderSettings.haloStrength = this.haloStrength;
		if (this.skyboxMatStr != "null")
		{
			Material material = ResourceLoader.Load(this.skyboxMatStr, typeof(Material)) as Material;
			if (material != null)
			{
				RenderSettings.skybox = material;
			}
		}
	}

	public void TextLoad(string[] strArray, ref int idx)
	{
		this.mapID = Convert.ToInt32(strArray[idx++]);
		float r = Convert.ToSingle(strArray[idx++]);
		float g = Convert.ToSingle(strArray[idx++]);
		float b = Convert.ToSingle(strArray[idx++]);
		float a = Convert.ToSingle(strArray[idx++]);
		this.ambientLight = new Color(r, g, b, a);
		this.flareStrength = Convert.ToSingle(strArray[idx++]);
		this.fog = Convert.ToBoolean(strArray[idx++]);
		r = Convert.ToSingle(strArray[idx++]);
		g = Convert.ToSingle(strArray[idx++]);
		b = Convert.ToSingle(strArray[idx++]);
		a = Convert.ToSingle(strArray[idx++]);
		this.fogColor = new Color(r, g, b, a);
		this.fogDensity = Convert.ToSingle(strArray[idx++]);
		this.fogEndDistance = Convert.ToSingle(strArray[idx++]);
		this.fogMode = (FogMode)Convert.ToInt32(strArray[idx++]);
		this.fogStartDistance = Convert.ToSingle(strArray[idx++]);
		this.haloStrength = Convert.ToSingle(strArray[idx++]);
		this.skyboxMatStr = strArray[idx++];
	}
}
