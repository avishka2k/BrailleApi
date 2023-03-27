using Microsoft.AspNetCore.Mvc;

namespace BrailleApi.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class TextController : ControllerBase
    {
        [HttpGet("text/{text}")]
        public IActionResult GetBraille(string text)
        {
            string braille = "";
            foreach (char c in text)
            {
                if (c >= 'a' && c <= 'z')
                {
                    braille += braille_a_to_z[c - 'a'];
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    braille += braille_A_to_Z[c - 'A'];
                }
                else if (c >= '0' && c <= '9')
                {
                    braille += braille_0_to_9[c - '0'];
                }
                else
                {
                    braille += " ";
                }
            }
            return Ok(braille);
        }

        private static string[] braille_a_to_z = new string[]
        {
            "⠁", "⠃", "⠉", "⠙", "⠑", "⠋", "⠛", "⠓", "⠊", "⠚",
            "⠅", "⠇", "⠍", "⠝", "⠕", "⠏", "⠟", "⠗", "⠎", "⠞",
            "⠥", "⠧", "⠺", "⠭", "⠽", "⠵"
        };

        private static string[] braille_A_to_Z = new string[]
        {
            "⠠⠁", "⠠⠃", "⠠⠉", "⠠⠙", "⠠⠑", "⠠⠋", "⠠⠛", "⠠⠓", "⠠⠊", "⠠⠚",
            "⠠⠅", "⠠⠇", "⠠⠍", "⠠⠝", "⠠⠕", "⠠⠏", "⠠⠟", "⠠⠗", "⠠⠎", "⠠⠞",
            "⠠⠥", "⠠⠧", "⠠⠺", "⠠⠭", "⠠⠽", "⠠⠵"
        };

        private static string[] braille_0_to_9 = new string[]
        {
            "⠚", "⠁⠃", "⠉⠙", "⠑⠋", "⠍⠝", "⠕⠏", "⠋⠟", "⠛⠗", "⠓⠎", "⠊⠞"
        };

    }
}
