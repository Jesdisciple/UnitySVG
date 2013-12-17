using UnityEngine;
using System;
using System.Diagnostics;

namespace Grault.UnitySVG
{
	public class Invoke : MonoBehaviour
	{
		[SerializeField]
		private string svgPath = null;
		[SerializeField]
		private	Vector2 svgSize = default(Vector2);

		void Start ()
		{
			renderer.material.LoadSvg (this.svgPath, this.svgSize);
			UnityEngine.Debug.Log (renderer.material);
		}
	}
}