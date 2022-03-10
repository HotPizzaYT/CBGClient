# Chromebook Gang C# client
This is a client for Chromebook Gang.

The reason why I made this open source is that it uses the same code (albeit different languages) on the PC, mobile, and 3DS versions.

This should work on any system with .NET 4.5 installed. If your system does not support .NET 4.5, you're out of luck.

# Tests

Windows 10: Working

Windows 7: ?

Windows Vista: ?

Windows XP: ?

# How to compile

First of all, download and extract the code.

Install `Visual Studio Code 2019` (if you haven't already) and copy these files into your source/repos folder. Next you want to open them in `Visual Studio 2019`

It should pop up as a WinForms C# project. Click Build -> Bulid Solution, and it should generate a working EXE files.

# Known bugs

Sending messages take a second to send

~~Message box won't focus while refreshing~~ Now fixed.

WebView not caching images

# Ports to other platforms

Ports to other platforms (such as Linux or ARM Windows) are always welcome, just make sure to fork this project and update the code as this code is being updated.
