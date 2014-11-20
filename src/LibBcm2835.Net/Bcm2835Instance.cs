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
using System;

namespace LibBcm2835.Net
{
  public sealed partial class Bcm2835
  {
    #region "Instance Singleton"
    private static readonly Lazy<Bcm2835> _lazy =
        new Lazy<Bcm2835>(() => new Bcm2835());

    /// <summary>
    /// Gets an (singleton) instance of the wrapper of the bcm2835.c/h functions.
    /// </summary>
    public static Bcm2835 Instance { get { return _lazy.Value; } }
    #endregion
  }
}
