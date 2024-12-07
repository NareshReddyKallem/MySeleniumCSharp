namespace POMFramework.TestData
{
    public static class GlobalTestData
    {
        public static string browser = AppSettings.Instance.BrowserName;
        public static string url = AppSettings.Instance.ApplicationURL;
        public static string userName = AppSettings.Instance.UserName;
        public static string pwd = AppSettings.Instance.UserPass;

        public static string normalData = "Test123";

        public static string invalidUsernamePlain = "invalidUser";
        public static string invalidUsernameAlphaNumeric = "invalidUser12345";
        public static string invalidUsernameWithSpecialChars = "invalidUser@$@$";
        public static string invalidUsernameWithNumbersAndSpecialChars = "invalidUser123@$@$";

        public static string validUsername = "admin";
        public static string validPassword = "admin@1234";

        public static string invalidPassword = "invalid-password";
        public static string invalidPasswordWithNumbers = "invalid-password123";
        public static string invalidPasswordWithNumbersAndSpecialChars = "invalid123password@$@$@";




    }
}
