using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace WebApplicationMvc.Models.Dtos
{
    public class DetailsFilter : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "id asc";
            }
            return base.Validate(validationContext);
        }
    }
}