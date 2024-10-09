namespace DSAProject.UtilityModule
{
    public static class PhoneNumberValidator
    {
        /// <summary>
        /// Validates that the phone number is exactly 5 digits long and starts with '0' for our demo purposes - else we need to implement a more complex validations
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool ValidatePhoneNumber(string phone)
        {
            if (phone.Length == 5 && phone.StartsWith("0"))
            {
                Console.WriteLine($"Phone number '{phone}' is valid.");
                return true;
            }
            else
            {
                Console.WriteLine($"Phone number '{phone}' is invalid. It must start with '0' and be 5 digits long.");
                return false;
            }
        }
    }
}
