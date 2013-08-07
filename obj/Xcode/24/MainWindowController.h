// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface MainWindowController : NSWindowController {
	IKImageBrowserView *_browserView;
	QTMovieView *_movieView;
	NSButton *_nextMovieButton;
	NSButton *_playMovieButton;
	NSButton *_prevMovieButton;
}

@property (nonatomic, retain) IBOutlet IKImageBrowserView *browserView;

@property (nonatomic, retain) IBOutlet QTMovieView *movieView;

@property (nonatomic, retain) IBOutlet NSButton *nextMovieButton;

@property (nonatomic, retain) IBOutlet NSButton *playMovieButton;

@property (nonatomic, retain) IBOutlet NSButton *prevMovieButton;

- (IBAction)SearchTextChanged:(NSSearchField *)sender;

- (IBAction)AddButtonClicked:(NSButton *)sender;

- (IBAction)pauseButtonClicked:(id)sender;

- (IBAction)SliderChanged:(NSSlider *)sender;

@end
