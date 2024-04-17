using System.Diagnostics.Contracts;

namespace UtilityLibrary
{
    public static class RegistrationLibrary
    {
        public static bool areNull(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Contract.Requires<ArgumentNullException>(str != null, "str");
                return true;
            }
            return false;
        }
    }
}