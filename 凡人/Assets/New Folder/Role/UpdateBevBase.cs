using System;

public class UpdateBevBase
{
    protected bool isStarted;

    public bool Enable = true;

    public virtual bool Update()
	{
		return this.Enable;
	}

	public virtual float GetCurrentTime()
	{
		return 0f;
	}

	public virtual float GetLength()
	{
		return 0f;
	}

	public virtual void Quit()
	{
		this.Enable = false;
	}

	public virtual void Destroy()
	{
	}

	public virtual void Reset()
	{
		this.isStarted = false;
		this.Enable = true;
	}
}
