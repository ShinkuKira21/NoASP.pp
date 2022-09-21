using System.Runtime.InteropServices;

namespace Server.Communications;

// Entry Points (They match the Coms.h file)
public static class CPPPostData
{
    [DllImport("cPostLib")]
    static public extern IntPtr CPostReply([MarshalAs(UnmanagedType.LPStr)] string msg);
    
    [DllImport("cPostLib")]
    static public extern void DeleteCPointer(IntPtr cPointer);
}