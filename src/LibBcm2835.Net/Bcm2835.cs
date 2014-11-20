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
using LibBcm2835.Net.DllLoad;
using System;
using System.Runtime.InteropServices;

namespace LibBcm2835.Net
{
  public sealed partial class Bcm2835
  {

    #region "Private fields"
    private IntPtr _dllHandle = IntPtr.Zero;
    private IDllLoad _dllLoad = null;
    #endregion

    #region "Constructors/Destructors"
    private Bcm2835()
    {
      if (!IsLinux())
      {
        throw new PlatformNotSupportedException("Intended to run on a Linux version for the Raspberry Pi.");
      }

      if (!LibBcm2835SoFileInfo.Exists)
      {
        throw new DllNotFoundException("Unable to find libbcm2835.so library");
      }

      try
      {
        _dllLoad = new DllLoadLinux();
        _dllHandle = _dllLoad.LoadLibrary(LibBcm2835SoFileInfo.FullName);

        InitializeDelegates();
      }
      catch (Exception ex)
      {
        throw new Exception("Unable to initialize libbcm2835.so library", ex);
      }
    }

    ~Bcm2835()
    {
      if (_dllHandle != IntPtr.Zero)
      {
        _dllLoad.FreeLibrary(_dllHandle);
      }
    }
    #endregion


    private T GetDelegate<T>(string name, T unresolved)
    {
      try
      {
        return (T)(object)Marshal.GetDelegateForFunctionPointer(_dllLoad.GetProcAddress(_dllHandle, name), typeof(T));
      }
      catch (MissingMethodException)
      {
        return unresolved;
      }
    }

    private bool IsLinux()
    {
      var p = (int)Environment.OSVersion.Platform;
      return (p == 4) || (p == 6) || (p == 128);
    }
  }

}
