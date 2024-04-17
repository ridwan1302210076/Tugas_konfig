using jalankan_program_menu;
using menu_pembelian;
using Registration;
using System.Net.Http.Json;

public class Program
{

    static async Task Main(string[] args)
    {
        bool isRunning = true;
        bool islogin = false;
        while (isRunning)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Keluar");

            Console.Write("Pilihan Anda: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    //Login();

                    break;
                case "2":
                    RegistrationClass.registrationPage();

                    break;
                case "3":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }
            if (islogin)
            {
                while (true)
                {
                    Console.WriteLine("=========DASBORD=========");
                    Console.WriteLine("1. MENU ");
                    Console.WriteLine("2. PEMBAYARAN ");
                    Console.WriteLine("3. keluar ");
                    Console.Write("Pilih opsi (1-3): ");
                    string i = Console.ReadLine();
                    switch (i)
                    {
                        case "1":
                            MenuApiClient menuApiClient = new MenuApiClient();
                            while (true)
                            {
                                Console.WriteLine("Menu:");
                                Console.WriteLine("1. Cari Menu");
                                Console.WriteLine("2. Tambah Menu");
                                Console.WriteLine("3. Perbarui Menu");
                                Console.WriteLine("4. hapus menu");
                                Console.WriteLine("5. tampilkan semua menu");
                                Console.WriteLine("6. Keluar");
                                Console.WriteLine("Pilih opsi (1-4):");

                                string userInput = Console.ReadLine();

                                switch (userInput)
                                {
                                    case "1":
                                        await menuApiClient.SearchMenu();
                                        break;
                                    case "2":
                                        await menuApiClient.AddMenu();
                                        break;
                                    case "3":
                                        await menuApiClient.UpdateMenu();
                                        break;
                                    case "4":
                                        await menuApiClient.DeleteMenuByNama();
                                        break;
                                    case "5":
                                        await menuApiClient.ShowAllMenus();
                                        break;
                                    case "6":
                                        return;
                                    default:
                                        Console.WriteLine("Opsi tidak valid. Silakan pilih opsi yang benar.");
                                        break;
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("pihan anda tidak ada mohon masukan kembali");
                            break;


                    }
                }





            }


        }


    }
}

   