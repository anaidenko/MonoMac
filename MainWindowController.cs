
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ImageKit;
using MonoMac;

namespace SpotlightMonoMacPoC
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		private bool isPlaying = false;

		#region Constructors

		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		// Call to load from the XIB/NIB file
		public MainWindowController () : base("MainWindow")
		{
			Initialize ();
		}

		// Shared initialization code
		void Initialize ()
		{
		}

		#endregion

		//strongly typed window accessor
		public new MainWindow Window {
			get { return (MainWindow)base.Window; }
		}

		public override void AwakeFromNib ()
		{
			var desktopPath = Environment.GetFolderPath (Environment.SpecialFolder.Desktop);
			browseData.AddImages (NSUrl.FromFilename (desktopPath + "/"));
			browserView.DataSource = browseData;
			browserView.ReloadData();

			//setup delegate for drag and drop
			browserView.DraggingDestinationDelegate = new DragDelegate (browserView);

			// set up event handlers just for testing
			browserView.BackgroundWasRightClicked += delegate { Console.WriteLine ("BackgroundWasRightClicked"); };
			browserView.SelectionDidChange += delegate { Console.WriteLine ("SelectionDidChange"); };
			browserView.CellWasDoubleClicked += delegate { Console.WriteLine ("CellWasDoubleClicked"); };
			browserView.CellWasRightClicked += delegate { Console.WriteLine ("CellWasRightClicked"); };

			browserView.CellWasDoubleClicked += PlaybackMovie;

			playMovieButton.Activated += PlayClicked;
			prevMovieButton.Activated += PrevMovieClicked;
		}

		private BrowseData browseData = new BrowseData();

		private void PrevMovieClicked(object sender, EventArgs e)
		{
		}

		private void PlayClicked(object sender, EventArgs e)
		{
			if (isPlaying)
			{
				movieView.Pause (this);
				playMovieButton.Image = NSImage.ImageNamed ("black_play_normal.png");
			}
			else
			{
				movieView.Play (this);
				playMovieButton.Image = NSImage.ImageNamed ("black_pause_normal.png");
			}

			isPlaying = !isPlaying;
		}

		private void PlaybackMovie(object sender, IKImageBrowserViewIndexEventArgs e)
		{
			var movieInfo = browseData.GetItem(browserView, e.Index);
			var moviePath = movieInfo.ImageRepresentation as NSUrl;
			var error = new NSError ();

			movieView.Movie = new MonoMac.QTKit.QTMovie (moviePath, out error);
			isPlaying = false;
			PlayClicked (this, EventArgs.Empty);
		}

		#region interface actions
		partial void SearchTextChanged (NSSearchField sender)
		{
			browseData.SetFilter(sender.StringValue);
			browserView.ReloadData ();
		}

		partial void AddButtonClicked (NSButton sender)
		{
			var panel = NSOpenPanel.OpenPanel;
			panel.FloatingPanel = true;
			panel.CanChooseDirectories = true;
			panel.CanChooseFiles = true;
			//FIXME - create enum for open/save panel return code
			int i = panel.RunModal ();
			if (i == 1 && panel.Urls != null) {
				foreach (NSUrl url in panel.Urls) {
					browseData.AddImages (url);
				}
				browserView.ReloadData ();
			}
		}

		partial void pauseButtonClicked (MonoMac.Foundation.NSObject sender)
		{
			//movieView.Pause(this);
			//movieView.EnterFullscreenModeWithOptions(NSScreen.MainScreen, new NSDictionary());
		}
		#endregion

	}
}

