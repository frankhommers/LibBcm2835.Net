#region License
//The MIT License (MIT)

//Copyright (c) 2014 Frank Hommers ( http://hmm.rs/LibBcm2835.Net )

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
#endregion
// blink C#
//
// Example program for LibBcm2835.Net library
// Blinks a pin on an off every 0.5 secs
//
// Compile with Visual Studio, copy the output
// dir to your RaspberryPi and run it with
//
// sudo mono Blink.exe
//
// Author: Frank Hommers
// Copyright (C) 2014 Frank Hommers
// 

using LibBcm2835.Net;
using System;

namespace Blink
{
  class Program
  {
    // Blinks on RPi Plug P1 pin 11 (which is GPIO pin 17)
    public const Byte pin = (byte)Bcm2835.RPiGPIOPin.RPI_V2_GPIO_P1_07;

    static int Main(string[] args)
    {
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
      bcm2835.bcm2835_close();
      return 0;
    }
  }
}
