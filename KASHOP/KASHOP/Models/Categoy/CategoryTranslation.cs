namespace KASHOP.Models.Categoy
{
    public class CategoryTranslation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Language { get; set; } ="en";
        //للعلاقة بين الجدولين
        public int Categoryid { get; set; }

        public Category Category { get; set; }
    }
}
