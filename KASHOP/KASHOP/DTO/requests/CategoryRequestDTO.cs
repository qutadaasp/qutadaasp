using KASHOP.Models;
using System.Collections.Generic;

namespace KASHOP.DTO.requests
{
    public class CategoryRequestDTO
    {
        public Status status { get; set; } = Status.Active;
       public List<CategoryTranslationRequest> categorytranslations { get; set; }
    }
}
