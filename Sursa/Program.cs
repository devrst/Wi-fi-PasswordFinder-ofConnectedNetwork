using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace ConsoleApplication8
{
    //Creat de Minca Andrei@Dev Rst
    class Program
    {
        static void Main(string[] args)
        {
          Process cmd = new Process();
          
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.Arguments = "/c netsh wlan show profiles";
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardError = true;
            cmd.Start();
            //* Read the output (or the error)
            string output = cmd.StandardOutput.ReadToEnd();
            
            
            string err = cmd.StandardError.ReadToEnd();
            Console.WriteLine(err);
            cmd.WaitForExit();
          //  Console.Read();
            int semafor=0;
            string ssid = "";
            try{
            for (int i = 0; i < output.Length; i++) 
            {
                if (output[i]==':') semafor++;
                if (semafor == 2 && output[i] != ' ' && output[i] != '\n' && output[i] != ':') ssid += output[i];
            }
            }
            catch{}
           
           
           
            Process cmd1 = new Process();
            string newSsid = "";
            cmd1.StartInfo.FileName = "cmd.exe";
            for (int i = 0; i < ssid.Length; i++) 
            {
                if (char.IsLetter(ssid[i])||char.IsDigit(ssid[i]))
                {
                    newSsid += ssid[i];
                }
            }
           
            
            cmd1.StartInfo.Arguments = @"/c Netsh Wlan show profiles """+newSsid+@""" key=clear";
            cmd1.StartInfo.UseShellExecute = false;
            cmd1.StartInfo.RedirectStandardOutput = true;
            cmd1.StartInfo.RedirectStandardError = true;
            cmd1.Start();
            //* Read the output (or the error)
            string output1 = cmd1.StandardOutput.ReadToEnd();


            string err1 = cmd1.StandardError.ReadToEnd();
          
            cmd1.WaitForExit();
            semafor = 0;
            string password1 = "";
            try
            {
                for (int i = 0; i < output1.Length; i++)
                {
                    if (output1[i] == ':') semafor++;
                    if (semafor == 18 && output1[i] != ' ' && output1[i] != '\n' && output1[i] != ':') password1 += output1[i];
                }
            }
            catch { }

            System.IO.File.AppendAllText(@"Logs.txt", "\nSSID:" + ssid + "\nPassword:" + password1);
            

            //output.Substring();
            //Netsh Wlan show profiles "network name" key=clear
        }
    }
}
