
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Drawing;

namespace SpotlightMonoMacPoC
{
	public partial class MainWindow : MonoMac.AppKit.NSWindow
	{
		#region Constructors

		// Called when created from unmanaged code
		public MainWindow (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public MainWindow (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		// Shared initialization code
		void Initialize ()
		{
		}
		
		#endregion

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			prevMovieButton.SetFrameSize (new SizeF (40, 40));

			var playButtonNewLocation = new PointF (
				playButton.Frame.Left + (playButton.Frame.Size.Width - 50) / 2,
				playButton.Frame.Top + (playButton.Frame.Size.Height - 50) / 2);
			playButton.Frame = new RectangleF (playButtonNewLocation, new SizeF (50, 50));

			nextMovieButton.SetFrameSize (new SizeF (40, 40));
		}
	}
}

