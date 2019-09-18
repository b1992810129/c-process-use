using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(Execute("echo hello", 10));
            Console.Write(Execute("cd", 10));
        }
        public static string Execute(string command, int seconds)
        {
            string output = "";
            if (command != null && !command.Equals(""))
            {
                Process process = new Process();//创建进程对象  
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";//设定需要执行的命令  
                startInfo.Arguments = "/C " + command;//“/C”表示执行完命令后马上退出  
                startInfo.UseShellExecute = false;//不使用系统外壳程序启动 
                startInfo.RedirectStandardInput = false;//不重定向输入  
                startInfo.RedirectStandardOutput = false; //重定向输出  
                startInfo.CreateNoWindow = true;//不创建窗口  
                process.StartInfo = startInfo;
                try
                {
                    if (process.Start())//开始进程  
                    {
                        if (seconds == 0)
                        {
                            process.WaitForExit();//这里无限等待进程结束  
                        }
                        else
                        {
                            process.WaitForExit(seconds); //等待进程结束，等待时间为指定的毫秒  
                        }
                        output = process.StandardOutput.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);//捕获异常，输出异常信息
                }
                finally
                {
                    if (process != null)
                        process.Close();
                }
                
            }
            return output;
        }
    }
}
