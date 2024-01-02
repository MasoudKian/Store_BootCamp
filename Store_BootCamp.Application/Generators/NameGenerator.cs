namespace Store_BootCamp.Application.Generators
{
    public class NameGenerator
    {
        public static string GenerateUniqEmailCode()
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }
    }
}
