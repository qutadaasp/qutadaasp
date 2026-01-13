namespace KASHOP.DTO.Response
{
    public class CategoriesResponseDTO
    {
       
        public int Id { get; set; }

        public List<CategoryTranslationResponse> CategoriesTranslation { get; set; }
    }
}
