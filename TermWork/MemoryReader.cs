using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace TermWork
{
    public class MemoryReader
    {

        const int PROCESS_WM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess
             (int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory
        (int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public static string Read(int PID, int address, int countOfSymbols)
        {
            Process process = Process.GetProcessById(PID);
            IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, process.Id);

            int bytesRead = 0;
            byte[] buffer = new byte[countOfSymbols * 2];



            ReadProcessMemory((int)processHandle, address, buffer, buffer.Length, ref bytesRead);
            string result;
            result = BitConverter.ToString(buffer);
            return result;
        }
        public static string ReadData(int PID, int address, int countOfSymbols)
        {
            Process process = Process.GetProcessById(PID);
            IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, process.Id);

            int bytesRead = 0;
            byte[] buffer = new byte[countOfSymbols * 2];



            ReadProcessMemory((int)processHandle, address, buffer, buffer.Length, ref bytesRead);
            char[] resultChar = new char[buffer.Length-1];
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] != 0)
                {
                    resultChar[i] = BitConverter.ToChar(buffer, i);
                }
            }
            string result = new string(resultChar);
            
            return result;
        }
    }
}
