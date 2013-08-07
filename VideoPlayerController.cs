using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace SpotlightMonoMacPoC
{
	public partial class VideoPlayerController : MonoMac.AppKit.NSViewController
	{
		#region Constructors
		// Called when created from unmanaged code
		public VideoPlayerController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public VideoPlayerController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		// Call to load from the XIB/NIB file
		public VideoPlayerController () : base ("VideoPlayer", NSBundle.MainBundle)
		{
			Initialize ();
		}
		// Shared initialization code
		void Initialize ()
		{
		}
		#endregion
		//strongly typed view accessor
		public new VideoPlayer View {
			get {
				return (VideoPlayer)base.View;
			}
		}
	}
}

