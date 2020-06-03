// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface NewsSourcesManagerController : NSViewController {
	NSButton *_AddItem;
	NSButton *_Exit;
	NSButton *_RemoveItem;
	NSTableView *_SourceList;
	NSTextField *_Title;
}

@property (nonatomic, retain) IBOutlet NSButton *AddItem;

@property (nonatomic, retain) IBOutlet NSButton *Exit;

@property (nonatomic, retain) IBOutlet NSButton *RemoveItem;

@property (nonatomic, retain) IBOutlet NSTableView *SourceList;

@property (nonatomic, retain) IBOutlet NSTextField *Title;

- (IBAction)Addsource:(id)sender;

- (IBAction)AddSource:(id)sender;

- (IBAction)ClosePanel:(id)sender;

- (IBAction)RemoveSource:(id)sender;

@end
