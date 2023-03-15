namespace Guide.Translate.AntiCorruption.DTO
{
    public class ChatGPTinputDTO
    {
        public ChatGPTinputDTO(string promptCommand)
        {
            model = "text-davinci-003";
            prompt = promptCommand;
            max_tokens = 100;
            temperature = 0.2M;
        }

        public string model { get; set; }
        public string prompt { get; set; }
        public int max_tokens { get; set; }
        public decimal temperature { get; set; }
    }
}
