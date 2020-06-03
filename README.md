# Gods-Eye
God's Eye is a backtesting software built on Cocoa with C# that is currently under development. It is planned to be released on the Mac App Store within 2020.

## Week 1:

    After tons of research, I determined that it was impossible to make a cross-platform app using the technologies I wanted to try out. So, I just decided to make a Cocoa project in Visual Studio for Mac using C#. Already created the app icon, main window, and found designs on Dribbble to base the design off. Also, decided to call it God's Eye because of that Fast & Furious Movie and because of the idea that the user will know what will happen in the future with the stock market. The window, btw, has a clear background where the real background is a NSView with a gradient layer.

## Week 2:

    This week I worked on the home screen and decided to add a news feature to it. First thing I did was make the window clear, make the background a dark blue gradient with 20 pixels available below it. Then I added the menu buttons which popped out a little bit from the bottom. All the gradient widgets have a 0.25 white border around it and the menu buttons are in a horizontal stack view. I used the NewsAPI and built a binary file that pulls the data from it and constructs the sentences in swift. I also made the domains available in a .txt file in the resources folder. I then created a sheet view controller to manage which news domains gets pulled from (add/remove). I then created the page view for the news articles in the homepage. Finally, I added a Network class that checks for internet availability during startup and adds a disconnected/reconnected listener. The AppDelegate and ViewController work together to use the methods.
