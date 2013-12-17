using UnityEngine;
using System.Collections;

namespace Grault.UnitySVG
{
	public class SvgCache : MonoBehaviour
	{
		private static SvgCache instance;

		#region static

		private static SvgAsset svgAsset = null;

		public static SvgAsset SvgAsset {
			get {
				if (svgAsset == null) {
					ISVGDevice device;
					if (instance.isFastAndLarge) {
						device = new SVGDeviceFast ();
					} else {
						device = new SVGDeviceSmall ();
					}

					svgAsset = new SvgAsset (device);
				}

				return svgAsset;
			}
		}

		public static Texture2D Load (string path, Vector2 size)
		{
			SvgAsset.SetFile (Resources.Load<TextAsset> (path));
			return SvgAsset.GetTexture (size);
		}

		#endregion

		#region instance

		[SerializeField]
		private bool isFastAndLarge = false;

		private void Awake ()
		{
			instance = this;
		}

		#endregion

	}
}