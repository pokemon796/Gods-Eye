// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface AddDomainViewController : NSViewController {
	NSTextField *_Description;
	NSButton *_Exit;
	NSButton *_Submit;
	NSTextField *_Title;
	NSTextField *_URLTextField;
}

@property (nonatomic, retain) IBOutlet NSTextField *Description;

@property (nonatomic, retain) IBOutlet NSButton *Exit;

@property (nonatomic, retain) IBOutlet NSButton *Submit;

@property (nonatomic, retain) IBOutlet NSTextField *Title;

@property (nonatomic, retain) IBOutlet NSTextField *URLTextField;

- (IBAction)Close:(id)sender;

- (IBAction)UserSubmittedNewSource:(id)sender;

@end
