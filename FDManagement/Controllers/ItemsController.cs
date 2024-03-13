using Microsoft.AspNetCore.Mvc;
using FDManagement.Repositories.Interface;
using FDManagement.Models.DTO;

namespace FDManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly IItemRepository itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await itemRepository.GetAllAsync();
            var response = new List<ItemsDto>();

            foreach(var item in items)
            {
                response.Add(new ItemsDto
                {
                    ID = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    SerialNumber = item.SerialNumber,
                    Value = item.Value,
                    Category = item.Category
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("api/[controller]/categories")]
        public async Task<IActionResult> GetAllCategories() 
        {
            var categories = await itemRepository.GetCategoriesAsync();
            var response = new List<CategoriesDto>();

            foreach (var category in categories) 
            {
                response.Add(new CategoriesDto
                {
                    ID = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                });
            }

            return Ok(response);
        }
    }
}
