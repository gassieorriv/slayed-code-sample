namespace SlayedLifeModels.Support
{
    public class SupportNoteDto
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string note { get; set; }
        public bool resolved { get; set; }
    }
}
