# AgOpenGPS build with mono

This is a first attempt to build with mono on Ubuntu.  Some functions work OK (in simulator mode) but issues remain:  
* Text in popup toolbars from bottom of screen overlap the images.
* Settings not saved.
* Hardware is completely untested.

I intend to revisit this when I have the hardware built but wanted to commit before I forget.

Changes not tested on Windows yet.

## Setup

* Ubuntu 19.10 but that probably doesn't matter.
* `sudo apt install mono-complete`
* `cd SourceCode/GPS`
* `xbuild`
* The .exe will be copied to AgOpenGPS/Program/

## Notes on changes so far
* All PNG button images converted to libpng png32 (with alpha channel) with ImageMagick convert
* Filename cases made consistent
* Google Earth KML chooser filter includes *.kml
* .Trim() on equipment for field directory

