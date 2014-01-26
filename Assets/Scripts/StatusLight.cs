﻿using UnityEngine;
using System.Collections;

public class StatusLight : MonoBehaviour 
{
	public Material InactiveMaterial;
	public Material StrikeMaterial;
	public float PanicBlinkRate;

	void Start()
	{
	}

	public void SetStrike(bool playAudio)
	{
		this.light.enabled = true;
		this.light.color = Color.red;
		this.renderer.material = StrikeMaterial;

		if (playAudio)
		{
			audio.Play();
		}
	}

	[ContextMenu("PanicTest")]
	public void StartPanic()
	{
		StartCoroutine(BlinkRoutine());
	}

	protected IEnumerator BlinkRoutine()
	{
		while(true)
		{
			SetStrike(false);
			yield return new WaitForSeconds(PanicBlinkRate);
			SetInactive();
			yield return new WaitForSeconds(PanicBlinkRate);
		}
	}

	public void SetInactive()
	{
		this.light.enabled = false;
		this.renderer.material = InactiveMaterial;
	}
}
