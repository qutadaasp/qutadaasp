namespace KASHOP.Models.Categoy
{
    public class Category : BaseModel
    {
        
        public List<CategoryTranslation> CategoryTranslations { get; set; } = new List<CategoryTranslation>();
        
    }
}
