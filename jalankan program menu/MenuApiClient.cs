using menu_pembelian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace jalankan_program_menu
{
    public class MenuApiClient
    {
        private static readonly HttpClient client = new HttpClient();
        private const string baseUrl = "http://localhost:5065/api/";

        public MenuApiClient()
        {
            // Set header untuk menerima response dalam format JSON
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task SearchMenu()
        {
            Console.WriteLine("Masukkan Nama Menu:");
            string namaMenu = Console.ReadLine();

            HttpResponseMessage menuByNamaResponse = await client.GetAsync(baseUrl + "menu/" + namaMenu);
            if (menuByNamaResponse.IsSuccessStatusCode)
            {
                menu menuByNama = await menuByNamaResponse.Content.ReadAsAsync<menu>();
                Console.WriteLine($"Menu dengan nama '{menuByNama.Nama}' ditemukan. Harga: {menuByNama.harga}");
            }
            else if (menuByNamaResponse.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Menu dengan nama '{namaMenu}' tidak ditemukan.");
            }
            else
            {
                string errorMessage = await menuByNamaResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorMessage}");
            }
        }

        public async Task AddMenu()
        {
            Console.WriteLine("Masukkan Nama Menu:");
            string namaMenu = Console.ReadLine();

            Console.WriteLine("Masukkan Harga Menu:");
            int hargaMenu;

            while (!int.TryParse(Console.ReadLine(), out hargaMenu))
            {
                Console.WriteLine("Harga tidak valid. Masukkan harga yang benar:");
            }

            Console.WriteLine("Masukkan Nama File Foto:");
            string fotoPath = Console.ReadLine();

            menu newMenu = new menu { Nama = namaMenu, harga = hargaMenu, foto = fotoPath };

            HttpResponseMessage createMenuResponse = await client.PostAsJsonAsync(baseUrl + "menu", newMenu);
            if (createMenuResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Menu baru berhasil ditambahkan.");
            }
            else
            {
                string errorMessage = await createMenuResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorMessage}");
            }
        }

        public async Task UpdateMenu()
        {
            Console.WriteLine("Masukkan Nama Menu:");
            string namaMenu = Console.ReadLine();

            HttpResponseMessage menuByNamaResponse = await client.GetAsync(baseUrl + "menu/" + namaMenu);
            if (menuByNamaResponse.IsSuccessStatusCode)
            {
                menu menuToUpdate = await menuByNamaResponse.Content.ReadAsAsync<menu>();

                Console.WriteLine($"Menu dengan nama '{menuToUpdate.Nama}' ditemukan. Harga saat ini: {menuToUpdate.harga}");
                Console.WriteLine("Masukkan harga baru:");
                int hargaMenu;
                while (!int.TryParse(Console.ReadLine(), out hargaMenu))
                {
                    Console.WriteLine("Harga tidak valid. Masukkan harga yang benar:");
                }

                menuToUpdate.harga = hargaMenu;

                HttpResponseMessage updateMenuResponse = await client.PutAsJsonAsync(baseUrl + "menu/" + namaMenu, menuToUpdate);
                if (updateMenuResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Menu berhasil diperbarui.");
                }
                else
                {
                    string errorMessage = await updateMenuResponse.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {errorMessage}");
                }
            }
            else if (menuByNamaResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Menu dengan nama '{namaMenu}' tidak ditemukan.");
            }
        }
        public async Task DeleteMenuByNama()
        {
            Console.WriteLine("Masukkan Nama Menu yang akan dihapus:");
            string namaMenu = Console.ReadLine();

            HttpResponseMessage menuByNamaResponse = await client.DeleteAsync(baseUrl + "menu/" + namaMenu);
            if (menuByNamaResponse.IsSuccessStatusCode)
            {
                Console.WriteLine($"Menu dengan nama '{namaMenu}' berhasil dihapus.");
            }
            else if (menuByNamaResponse.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Menu dengan nama '{namaMenu}' tidak ditemukan.");
            }
            else
            {
                string errorMessage = await menuByNamaResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorMessage}");
            }
        }
        public async Task ShowAllMenus()
        {
            HttpResponseMessage menusResponse = await client.GetAsync(baseUrl + "menu");
            if (menusResponse.IsSuccessStatusCode)
            {
                List<menu> menus = await menusResponse.Content.ReadAsAsync<List<menu>>();
                Console.WriteLine("Daftar Menu:");
                foreach (var menu in menus)
                {
                    Console.WriteLine($"Nama: {menu.Nama}\tHarga: {menu.harga}");
                }
            }
            else
            {
                string errorMessage = await menusResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorMessage}");
            }
        }
    }
}
