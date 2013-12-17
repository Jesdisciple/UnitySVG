using UnityEngine;
using System.Collections;

namespace Grault.UnitySVG
{
	public static class UnityExtensions
	{
		public static void LoadSvg (this Material m, string svgPath, Vector2 size)
		{
			m.mainTexture = SvgCache.Load (svgPath, size);
			Vector2 ts = m.mainTextureScale;
			ts.x *= -1;
			m.mainTextureScale = ts;
			m.mainTexture.filterMode = FilterMode.Trilinear;
		}
	}
}