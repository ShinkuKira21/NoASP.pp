using System.Runtime.InteropServices;

namespace Server.Communications;

// Entry Points (They match the Coms.h file)
public static class CPPPostData
{
    public static string PostReply(string msg)
    {
        /* The C++ version is basic implementation, but provides a method to process information
       at high performance, whether it's information from the front-end (or) ASP.NET backend.

       The C++ implementation is an add-on and does not have to be used. 
       However, the template is aimed to provide some sort of C++ implementation for further use.
       */

        // Converts IntPtr (const char*) to String

        IntPtr cPtr = CPostReply(msg);


        if (cPtr == IntPtr.Zero)
            throw new ApplicationException("C++ returned null pointer - potential memory leak!");
   
        String? cString = Marshal.PtrToStringAnsi(cPtr);

        DeleteCPointer(cPtr);

        return string.IsNullOrEmpty(cString) ? "" : cString;
    }

    #if Windows
        private const string LibraryName = "cPostLib.dll";
    #else
        private const string LibraryName = "cPostLib";
    #endif

    [DllImport(LibraryName)]
    // Source: C++\Windows-Project\coms.cpp
    static private extern IntPtr CPostReply([MarshalAs(UnmanagedType.LPStr)] string msg);
    
    [DllImport(LibraryName)]
    static private extern void DeleteCPointer(IntPtr cPointer);
}