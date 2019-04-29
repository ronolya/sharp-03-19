using System.Threading.Tasks;
using System.IO;

namespace AudioPlayer.Classes
{
    public class FileManager
    {

        public async void WriteFile(string jsonStr)
        {
            using (StreamWriter writer = new StreamWriter("json.txt"))
            {
                await writer.WriteAsync(jsonStr);
            }

        }

        public async Task<string> ReadFile()
        {
            string jsonStr = null;
            using (StreamReader reader = new StreamReader("json.txt"))
            {

                jsonStr = await reader.ReadToEndAsync();
            }
            return jsonStr;
        }

       public bool IsExistFile()
        {
          return  File.Exists("json.txt");
        }


    }
}
