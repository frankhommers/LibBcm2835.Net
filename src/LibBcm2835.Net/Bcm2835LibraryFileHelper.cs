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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace LibBcm2835.Net
{
  public sealed partial class Bcm2835
  {
    /// <summary>
    /// Private static class to keep track of the location of the libbcm2835.so file.
    /// </summary>
    private static class LibraryLocation
    {
      private static FileInfo _libBcm2835SoFileInfo = null;

      static LibraryLocation()
      {
        Assembly executingAssembly = Assembly.GetExecutingAssembly();
        FileInfo asmFileInfo = new FileInfo(executingAssembly.Location);
        _libBcm2835SoFileInfo = new FileInfo(Path.Combine(asmFileInfo.DirectoryName, "libbcm2835.so"));
      }

      static internal void SetManualLocation(string fileName)
      {
        _libBcm2835SoFileInfo = new FileInfo(fileName);
        if (!_libBcm2835SoFileInfo.Exists) throw new DllNotFoundException(string.Format("Library not found ({0}).", fileName));
      }

      static internal FileInfo LibBcm2835SoFileInfo
      {
        get
        {
          if (_libBcm2835SoFileInfo != null) _libBcm2835SoFileInfo.Refresh();
          return _libBcm2835SoFileInfo;
        }
      }

    }

    #region "Methods"
    public static void UseManualLibraryLocation(string fileName)
    {
      LibraryLocation.SetManualLocation(fileName);
    }

    public static bool LibraryExists()
    {
      return LibraryLocation.LibBcm2835SoFileInfo.Exists;
    }

    public static void ExtractAndCompileLibraryIfNotExists()
    {
      if (LibraryLocation.LibBcm2835SoFileInfo.Exists) return;
      ExtractAndCompileLibrary();
    }

    public static void ExtractAndCompileLibrary()
    {
      DirectoryInfo createdDirectory = null;

      try
      {
        const string archivedLibFileName = "bcm2835-1.52.tar.gz";
        string tempPath = Path.Combine(Path.GetTempPath(), System.Guid.NewGuid().ToString().ToLower());
        string tempFileName = Path.Combine(tempPath, archivedLibFileName);
        createdDirectory = Directory.CreateDirectory(tempPath);
        WriteResourceToFile(tempFileName, archivedLibFileName);

        Shell(null, "Untarring to " + tempPath, "tar",
          "-zxvf \"" + tempFileName + "\" -C \"" + createdDirectory.FullName + "\"");

        DirectoryInfo tempPathDirectoryInfo = new DirectoryInfo(tempPath);
        FileInfo configureFile = FindFile(tempPathDirectoryInfo, "configure");
        string workDir = configureFile.Directory.FullName;

        Shell(workDir, "Running configure", Path.Combine(workDir, "configure"), null);
        Shell(workDir, "Running make", "make", null);
        FileInfo objectFile = FindFile(tempPathDirectoryInfo, "bcm2835.o");
        workDir = objectFile.Directory.FullName;
        Shell(workDir, "Running cc", "cc", "-shared bcm2835.o -o libbcm2835.so");
        WriteCaption("Copying result");
        FileInfo libFile = FindFile(tempPathDirectoryInfo, "libbcm2835.so");
        libFile.CopyTo(LibraryLocation.LibBcm2835SoFileInfo.FullName);

      }
      catch (Exception ex)
      {
        const string errorMessage = "Error occurred while trying to extract and compile the libbcm2835.so library.";
        Console.WriteLine("{0} ({1}).", errorMessage, ex.Message);
        throw new DllNotFoundException(errorMessage, ex);
      }
      finally
      {
        if (createdDirectory != null)
          createdDirectory.Delete(true);
      }
    }

    #endregion

    #region "Properties"
    public static FileInfo LibBcm2835SoFileInfo
    {
      get { return LibraryLocation.LibBcm2835SoFileInfo; }
    }
    #endregion

    #region "Private utility methods"
    private static void WriteResourceToFile(string fileName, string resourceName)
    {
      using (
        Stream rsrcStream =
          Assembly.GetExecutingAssembly().GetManifestResourceStream("LibBcm2835.Net." + resourceName))
      {
        MemoryStream memoryStream = new MemoryStream();
        rsrcStream.CopyTo(memoryStream);
        File.WriteAllBytes(fileName, memoryStream.ToArray());
      }
    }

    private static FileInfo FindFile(DirectoryInfo directory, string searchPattern)
    {
      IEnumerable<FileInfo> files = directory.EnumerateFiles(searchPattern,
        SearchOption.AllDirectories);
      foreach (FileInfo file in files)
      {
        return file;
      }
      return null;
    }

    private static void Shell(string workingDirectory, string caption, string fileName, string arguments)
    {
      if (!string.IsNullOrWhiteSpace(caption))
      {
        WriteCaption(caption);
      }

      ProcessStartInfo processStartInfo = new ProcessStartInfo();
      processStartInfo.UseShellExecute = true;
      processStartInfo.WorkingDirectory = workingDirectory;
      processStartInfo.FileName = fileName;
      if (!string.IsNullOrWhiteSpace(arguments)) processStartInfo.Arguments = arguments;

      Console.WriteLine("Process: {0}", processStartInfo.FileName);
      Console.WriteLine("Working Dir: {0}", processStartInfo.WorkingDirectory);
      Console.WriteLine("Arguments: {0}", processStartInfo.Arguments);
      Console.WriteLine("Starting...");
      Process process = Process.Start(processStartInfo);
      process.WaitForExit();
    }

    private static void WriteCaption(string caption)
    {
      Console.WriteLine("".PadLeft((caption ?? "").Length, '='));
      Console.WriteLine(caption);
      Console.WriteLine("".PadLeft((caption ?? "").Length, '-'));
    }
    #endregion
  }
}
