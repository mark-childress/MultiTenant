//using System.Text.RegularExpressions;

//namespace WebApp.Models
//{
//    public class Utils
//    {
//        internal static int SlugLength = 75;

//        public string GenerateSlug(string phrase)
//        {
//            string str = RemoveAccent(phrase).ToLower();
//            //invalid chars
//            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
//            //convert multiple spaces into one space
//            str = Regex.Replace(str, @"[\s+]", "");
//            //cut and trim
//            str = str.Substring(0, str.Length);//str.Length <= SlugLength);
//            str = Regex.Replace(str, @"[\s]", "-");
//            return str;
//        }

//        private string RemoveAccent(string txt)
//        {
//            return txt;
//        }
//    }
//}