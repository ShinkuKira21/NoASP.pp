/* Author(s): Edward Patch */
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Server.Communications;

// Named after the Server folder. (Feel free to rename or replace namespaces or classes)
namespace Server.Controllers;

[ApiController]
[Route("api")]
public class APIController : ControllerBase
{
    [HttpGet]
    public ActionResult<String> APIPing()
    { return Ok("Helloworld from the friendly ASP.NET Web API!"); }
    
    [HttpGet]
    [Route("Multiply")]
    public ActionResult<decimal> APIMultiply(decimal num1, decimal num2)
    { return Ok(num1 * num2); }

    [HttpPost]
    [Route("PostExample")]
    public ActionResult<String> APICExample([FromBody] String name)
    {
        /* HotTip: To store or get this information for long term use, take a dive into:-
        YouTube Video: https://www.youtube.com/watch?v=ZXdFisA_hOY - freeCodeCamp.org
        Microsoft Docs: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/
        start-mvc?view=aspnetcore-6.0&tabs=visual-studio
        */
        return Ok("Hello " + name + "! This is a message from C#");
    }

    [HttpPost]
    [Route("CppPost")]
    public ActionResult<String> CppPost([FromBody] String name)
    {
        /* The C++ version is basic implementation, but provides a method to process information
         at high performance, whether it's information from the front-end (or) ASP.NET backend.
         
         The C++ implementation is an add-on and does not have to be used. 
         However, the template is aimed to provide some sort of C++ implementation for further use.
         */

        // Converts IntPtr (const char*) to String
        IntPtr cPtr = CPPPostData.CPostReply(name);
        if(cPtr == IntPtr.Zero)
        { return BadRequest("Error: C++ Post Failed!"); }

        String cString = Marshal.PtrToStringAnsi(cPtr);
        CPPPostData.DeleteCPointer(cPtr);

        return Ok(cString);
    }
}