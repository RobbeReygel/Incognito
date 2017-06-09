using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Management;

namespace Incognito
{
    class Program
    {
        static void Main(string[] args)
        {

            InternetConn CheckConn = new InternetConn();
            WriteImage WriteImg = new WriteImage();
            Hwid WriteHwid = new Hwid();
            MacAddress WriteMac = new MacAddress();
            LocalIP WriteLocalIP = new LocalIP();
            PublicIP WriteExternalIP = new PublicIP();
            
            //if (CheckConn.CheckForInternetConnection() == true)
            //{

                Bitmap Invictus = WriteImg.LoadPicture("http://i.huffpost.com/gen/799955/thumbs/o-THE-MATRIX-AND-HINDUISM-facebook.jpg");

                WriteImg.ConsoleWriteImage(Invictus);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n\n   Incognito");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" - ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("Tool made by Rob \n\n\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("   Press [Enter] to start analysis\n\n");
                while (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("   Gathering Info about your machine...\n\n");
                    //System.Threading.Thread.Sleep(1000);

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    //Get HWID
                    Console.Write("   Your HardwareID: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(WriteHwid.getHWID() + "\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //Get Mac Address
                    Console.Write("   Mac address: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(WriteMac.getMac() + "\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //Get Local IP Address
                    Console.Write("   Local IP address (IPV4): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(WriteLocalIP.GetLocalIPAddress() + "\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //Get Public IP Address
                    Console.Write("   Public IP address (IPV6): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(WriteExternalIP.GetPublicIPAddress());
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Write("\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("   ------------------------------------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n");

                    Console.Write("   [");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("F7");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("] To change your HWID\n");

                    Console.Write("   [");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("F8");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("] To change your Mac Address\n");

                    Console.Write("   [");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("F9");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("] To delete EAC Files\n");

                    Console.Write("   [");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("ESC");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("] Secure exit\n");

                bool hwidReset = false;
                    bool macReset = false;
                    bool fileRemoval = false;

                    while (!hwidReset || !macReset || !fileRemoval)
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.F7:
                                if (!hwidReset)
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 4);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("   [");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("DONE");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("]");
                                    Console.Write(" New HWID: ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("xxx-xxx-xxx");
                                    Console.SetCursorPosition(0, Console.CursorTop + 4);
                                    hwidReset = true;
                                }
                                break;
                            case ConsoleKey.F8:
                                if (!macReset)
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 3);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("   [");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("DONE");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("]");
                                    Console.Write(" New Mac Address: ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    string newMacAddr = WriteMac.GenerateMACAddress();
                                    WriteMac.setMAC(newMacAddr); 
                                    Console.Write(newMacAddr);
                                    Console.SetCursorPosition(0, Console.CursorTop + 3);
                                    macReset = true;
                                }
                                break;
                            case ConsoleKey.F9:
                                if (!fileRemoval)
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("   [");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("DONE");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("]");
                                    Console.Write(" Removed file [");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("test.txt");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("]");
                                    Console.SetCursorPosition(0, Console.CursorTop + 2);
                                    fileRemoval = true;
                                }
                                break;
                            case ConsoleKey.Escape:
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.Write("   Secure Shutdown...");
                                System.Threading.Thread.Sleep(1000);
                                Environment.Exit(0);
                                break;
                        }
                    }

                    Console.SetCursorPosition(0, Console.CursorTop + 1);
                    Console.Write("   All steps complete\n   Press [");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("ESC");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("] to Exit");
                    while (Console.ReadKey(true).Key == ConsoleKey.Escape)
                        {
                            Environment.Exit(0);
                        }

                    /*
                    if (Console.ReadKey(true).Key == ConsoleKey.F7)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 3);
                        Console.Write("   [");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("F7");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("] To change your HWID [");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("DONE");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("]\n");
                        Console.SetCursorPosition(0, Console.CursorTop + 3);
                        Console.Write("   New HWID: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("xxx-xxx-xxx");
                    }

                    if (Console.ReadKey(true).Key == ConsoleKey.F8)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                        Console.Write("   [");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("F8");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("] To change your Mac Address [");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("DONE");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("]\n");
                        Console.SetCursorPosition(0, Console.CursorTop + 2);
                        Console.Write("   New Mac Address: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string newMacAddr = WriteMac.generateNewMac(12);
                        Console.Write(newMacAddr);
                    }

                    if (Console.ReadKey(true).Key == ConsoleKey.F9)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.Write("   [");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("F9");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("] To delete EAC Files [");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("DONE");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("]\n");
                        Console.SetCursorPosition(0, Console.CursorTop + 1);
                        Console.Write("   Removed file [");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("test.txt");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("]\n");
                    }
                    */

                    /*
                    if (System.IO.File.Exists("C:/Users/gebruiker/Desktop/test.txt"))
                    { 
                        System.IO.File.Delete("C:/Users/gebruiker/Desktop/test.txt");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("test.txt successfully removed!\n");
                    }
                    else{
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("test.txt not found!\n");
                    }
                    */
                }
            /*}
            else {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n\n   Incognito");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" - ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("Tool made by Rob \n\n\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("   Internet connection is required to run this program!");
            }*/
            Console.ReadLine();
        }
    }
}
