using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Menu
{
    internal class Program
    {
        enum LoginMenu { MULAI, USERNAME, PASSWORD, ERROR, BERHASIL };
        static void Main(string[] args)
        {

            string[,] userTable = new string[,] { { "Andi Erlangga", "12345" }, { "noobmaster69", "09876" } };

            LoginMenu login = LoginMenu.MULAI;
            // menyimpan data username
            string TxtUsername = "";
            
            while (login != LoginMenu.ERROR && login != LoginMenu.BERHASIL)
            {
                switch (login)
                {
                    //jika login menu yang dipilih mulai akan muncul username yang akan dimasukan
                    case LoginMenu.MULAI:
                        Console.WriteLine("Masukkan Username Anda :");
                        login = LoginMenu.USERNAME;
                        break;
                    case LoginMenu.USERNAME:
                        TxtUsername = Console.ReadLine();
                        Console.WriteLine("Masukkan Password Anda :");
                        login = LoginMenu.PASSWORD;
                        break;
                    case LoginMenu.PASSWORD:
                        string TxtPassword = Console.ReadLine();

                        bool isValid = false;
                        for (int i = 0; i < userTable.GetLength(0); i++)
                        {
                            if (TxtUsername == userTable[i, 0] && TxtPassword == userTable[i, 1])
                            {
                                isValid = true;
                                break;
                            }
                        }

                        if (isValid)
                        {
                            Console.WriteLine("Login Berhasil!");
                            login = LoginMenu.BERHASIL;
                        }
                        else
                        {
                            Console.WriteLine("Username atau Password Salah. Silahkan Coba lagi!");
                            login = LoginMenu.ERROR;
                        }
                        break;
                }
            }

            // Tampilkan pesan jika login gagal
            if (login == LoginMenu.ERROR)
            {
                Console.WriteLine("Login failed!");
            }
        }
    }
}


