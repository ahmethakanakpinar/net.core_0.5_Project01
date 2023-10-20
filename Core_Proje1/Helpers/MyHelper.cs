namespace Core_Proje1.Helpers
{
    public class MyHelper
    {
        public static string DefaultImage(string input)
        {
            if(input == null || input == "")
            {
                return "pic-1.png";
            }
            else
            {
                return input;
            }

        }
    }
}
