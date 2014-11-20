#region License
//The MIT License (MIT)

//Copyright (c) 2014 Frank Hommers ( http://hmm.rs/Bcm2835.Net )

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
#region Attribution
// Loosely based on: http://dimitry-i.blogspot.com/2013/01/mononet-how-to-dynamically-load-native.html
#endregion
#define LINUXONLY
// This file is included for completeness.
#if !LINUXONLY
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace LibBcm2835.Net.DllLoad
{
  internal class DllLoadWindows : IDllLoad
  {
    void IDllLoad.FreeLibrary(IntPtr handle)
    {
      FreeLibrary(handle);
    }

    IntPtr IDllLoad.GetProcAddress(IntPtr dllHandle, string name)
    {
      IntPtr res = GetProcAddress(dllHandle, name);
      if (res == IntPtr.Zero)
      {
        throw new MissingMethodException(string.Format("GetProcAddress failed with error code {0}.", Marshal.GetLastWin32Error()));
      }
      return res;
    }

    IntPtr IDllLoad.LoadLibrary(string fileName)
    {
      IntPtr res = LoadLibrary(fileName);
      if (res == IntPtr.Zero)
      {
        throw new FileLoadException(string.Format("LoadLibrary failed with error code {0}.", Marshal.GetLastWin32Error()));
      }
      return res;
    }

    [DllImport("kernel32")]
    private static extern IntPtr LoadLibrary(string fileName);

    [DllImport("kernel32.dll")]
    private static extern int FreeLibrary(IntPtr handle);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetProcAddress(IntPtr handle, string procedureName);
  }
}
#endif