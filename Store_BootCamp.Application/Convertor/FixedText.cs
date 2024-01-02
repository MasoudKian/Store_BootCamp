namespace Store_BootCamp.Application.Convertor
{
    public class FixedText
    {
        public static string FixedEmail(string email)
        {
            return email.Trim().ToLower();
        }
        public static string FixedUserName(string username)
        {
            return username.Trim().ToLower();
        }

    }
}
