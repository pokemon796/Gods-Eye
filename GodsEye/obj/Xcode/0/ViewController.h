// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>
#import <GodsEye/GodsEye.h>

#import "MenuButton.h"

@interface ViewController : NSViewController {
	NSView *_Background;
	MenuButton *_CreateStrategy;
	NSTextField *_Headline;
	NSView *_InternetNotice;
	NSStackView *_Menu;
	NSView *_NewsPages;
	NSButton *_NewsSettings;
	MenuButton *_OpenStrategy;
	MenuButton *_SearchMarket;
	NSTextField *_Source;
	NSTextField *_SubTitleLabel;
	NSImageView *_TitleIcon;
	NSTextField *_TitleLabel;
	NSButton *_URL;
}

@property (nonatomic, retain) IBOutlet NSView *Background;

@property (nonatomic, retain) IBOutlet MenuButton *CreateStrategy;

@property (nonatomic, retain) IBOutlet NSTextField *Headline;

@property (nonatomic, retain) IBOutlet NSView *InternetNotice;

@property (nonatomic, retain) IBOutlet NSStackView *Menu;

@property (nonatomic, retain) IBOutlet NSView *NewsPages;

@property (nonatomic, retain) IBOutlet NSButton *NewsSettings;

@property (nonatomic, retain) IBOutlet MenuButton *OpenStrategy;

@property (nonatomic, retain) IBOutlet MenuButton *SearchMarket;

@property (nonatomic, retain) IBOutlet NSTextField *Source;

@property (nonatomic, retain) IBOutlet NSTextField *SubTitleLabel;

@property (nonatomic, retain) IBOutlet NSImageView *TitleIcon;

@property (nonatomic, retain) IBOutlet NSTextField *TitleLabel;

@property (nonatomic, retain) IBOutlet NSButton *URL;

- (IBAction)OpenNewsManagerPanel:(id)sender;

@end
