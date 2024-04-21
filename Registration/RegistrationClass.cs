using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using UtilityLibrary;

namespace Registration
{
    public class RegistrationClass
    {
        public RegistrationClass() 
        {

        }

        public static void registrationPage()
        {
            Console.WriteLine("\nRegistration page\n");

            string name;
            string username;
            string pw;
            string confirmpw;

            do
            {
                Console.WriteLine("Masukkan nama anda: ");
                name = Console.ReadLine();
            } while (RegistrationLibrary.areNull(name) == true);

            do
            {
                Console.WriteLine("\nMasukkan username anda: ");
                username = Console.ReadLine();
                if (checkUsername(username))
                {
                    Console.WriteLine("Username sudah ada, silahkan masukkan ulang.");
                }
            } while (checkUsername(username) == true || RegistrationLibrary.areNull(username) == true);

            do
            {
                Console.WriteLine("\nMasukkan password anda: ");
                pw = Console.ReadLine();
                if (!checkPassword(pw))
                {
                    Console.WriteLine("Password minimal 8 karakter\n");
                }
            } while (RegistrationLibrary.areNull(pw) == true || checkPassword(pw) == false);


            do
            {
                Console.WriteLine("\nKonfirmasi password anda: ");
                confirmpw = Console.ReadLine();
                if (pw != confirmpw)
                {
                    Console.WriteLine("password tidak sama, silahkan masukkan ulang\n");
                }
                else
                {
                     Console.WriteLine("Password telah dikonfirmasi.");

                }
            } while (pw != confirmpw || RegistrationLibrary.areNull(confirmpw) == true);

            createAkun(name, username, pw);

            Console.WriteLine("\nAkun Berhasil dibuat, silahkan login\n");
        }
        public static bool checkUsername(string username)
        {
            var initialJson = File.ReadAllText("user.json");
            dynamic data = JArray.Parse(initialJson);

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].username == username)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool checkPassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            return true;
        }

        public static void createAkun(string name, string username, string password)
        {
            var initialJson = File.ReadAllText("user.json");
            var array = JArray.Parse(initialJson);
            var itemToAdd = new JObject();
            itemToAdd["name"] = name;
            itemToAdd["username"] = username;
            itemToAdd["password"] = password;
            array.Add(itemToAdd);

            var jsonToOutput = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText("user.json", jsonToOutput);
        }
    }
}
