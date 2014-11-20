LibBcm2835.Net
==============

A .NET/Mono Wrapper for Mike McCauley's C library for Broadcom BCM 2835 as used in Raspberry Pi  
( http://www.airspayce.com/mikem/bcm2835/index.html )

Intended as a C#/.NET/Mono wrapper for the full functionality of that library.  

It already contains the bcm2835-1.xx.tar.gz file, it will try to extract and compile the library on first use. 
You can also supply your own libbcm2835.so file (just put it next to the dll on your target system). Make sure it's the same version as the one included here.


How to get started?
-------------------

* Install Mono on your Raspberry Pi.
```
sudo apt-get update
sudo apt-get install mono-complete
```
* Compile the sample Blink project.  
* Copy the output directory (at least Blink.exe and LibBcm2835.dll) to your Raspberry Pi.  
* Run  
```
sudo mono Blink.exe
```

Example
-------
This is based on the original blink.c.
```C#
// Blinks on RPi Plug P1 pin 11 (which is GPIO pin 17)
const Byte pin = (byte)Bcm2835.RPiGPIOPin.RPI_V2_GPIO_P1_07;

// Will extract (from embedded resource) and compile the library 
// if it doesn't exist in the same directory as LibBcm2835.dll.
Bcm2835.ExtractAndCompileLibraryIfNotExists();

// Grabbing the instance will dynamically load the libbcm2835.so 
// library, so make sure it's there before accessing this property.
Bcm2835 bcm2835 = Bcm2835.Instance;

// If you call this, it will not actually access the GPIO
// Use for testing
// bcm2835.bcm2835_set_debug(1);

if (bcm2835.bcm2835_init() == 0)
  return 1;

// Set the pin to be an output
bcm2835.bcm2835_gpio_fsel(pin, Bcm2835.HIGH);

while (true)
{
  // Turn it on
  bcm2835.bcm2835_gpio_write(pin, Bcm2835.HIGH);

  // wait a bit
  bcm2835.bcm2835_delay(500);

  // turn it off
  bcm2835.bcm2835_gpio_write(pin, Bcm2835.LOW);

  // wait a bit
  bcm2835.bcm2835_delay(500);
}
```

Notice
------
I only tested this on Raspbian. I assume it works on other distributions as well.
I will accept Pull Requests to make it (more) compatible with other distributions.


License
-------
The MIT License (MIT)

Copyright (c) 2014 Frank Hommers ( http://hmm.rs/LibBcm2835.Net )

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
