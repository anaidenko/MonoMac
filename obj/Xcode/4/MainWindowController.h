// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface MainWindowController : NSWindowController {
	IKImageBrowserView *_browserView;
}

@property (nonatomic, retain) IBOutlet IKImageBrowserView *browserView;

- (IBAction)SliderChanged:(NSSlider *)sender;

- (IBAction)SearchTextChanged:(NSSearchField *)sender;

- (IBAction)AddButtonClicked:(NSButton *)sender;

@end
