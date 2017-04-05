# Spotlight
Spotlight is a simple .NET application to copy Microsoft Spotlight images to your My Pictures directory.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

# Use

Simple program, simple to use. Just double-click **Spotlight.exe** to run the application. It will copy all files 1920 x 1080 or higher to **My Pictures\SpotlightPictures**.

It is recommended to create a scheduled task to run Spotlight. This will ensure you always have the most recent Microsoft Spotlight images available. You can learn about creating scheduled tasks [here](https://technet.microsoft.com/en-us/library/cc748993(v=ws.11).aspx). Alternatively, run `CreateSpotlightTask.bat` to create a task that will run weekly.


# Questions
**Couldn't this be done with a script?**

Yes.

**Why didn't you just write a script?**

Because I didn't want to.

**Seriously though, why didn't you?**

I wanted to keep all the Spotlight images and it was easier for me to write a .NET application to copy them for me than to write a script to do it.
