using System;
using System.Diagnostics;
using System.Management;

namespace GuideSmiths.Robots.Application.Utils
{
    public class  CloseProgram
    {
        public static void Close()
        {
            try
            {
                var query = string.Format("SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {0}", Process.GetCurrentProcess().Id);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", query);
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    var parentId = (uint)queryObj["ParentProcessId"];
                    var parent = Process.GetProcessById((int)parentId);

                    if (parent.ProcessName == "cmd")
                        parent.CloseMainWindow();

                }
            }
            catch (ManagementException ex)
            {
                Console.WriteLine("Error in WMI query: {0}", ex.Message);
            }
        }
    }
}
