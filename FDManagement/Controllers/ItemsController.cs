using Microsoft.AspNetCore.Mvc;
using FDManagement.Repositories.Interface;
using FDManagement.Models.DTO;
using System.Runtime.CompilerServices;

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

        [HttpPost]
        public async Task<IActionResult> CreateItem(ItemRequestDto itemDto)
        {
            var item = new Inventory_Item
            {
                Name = itemDto.Name,
                Description = itemDto.Description,
                SerialNumber = itemDto.SerialNumber,
                Value = itemDto.Value,
                CategoryId = itemDto.CategoryID
            };

            await itemRepository.CreateAsync(item);

            var response = new ItemDto
            {
                ID = item.Id,
                Name = item.Name,
                Description = item.Description,
                SerialNumber = item.SerialNumber,
                Value = item.Value,
                CategoryID = item.CategoryId
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("addcategory")]
        public async Task<IActionResult> CreateCategory(CategoryRequestDto categoryDto)
        {
            var category = new Inventory_Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description

            };

            await itemRepository.CreatCategoryAsync(category);

            var response = new CategoryDto
            {
                ID = category.Id,
                Name = category.Name,
                Description = category.Description,
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await itemRepository.GetAllAsync();
            var response = new List<ItemDto>();

            foreach (var item in items)
            {
                response.Add(new ItemDto
                {
                    ID = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    SerialNumber = item.SerialNumber,
                    Value = item.Value,
                    CategoryID = item.CategoryId,
                    CategoryName = item.Inventory_Category.Name
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await itemRepository.GetCategoriesAsync();
            var response = new List<CategoryDto>();

            foreach (var category in categories)
            {
                response.Add(new CategoryDto
                {
                    ID = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetItemById([FromRoute] int id)
        {
            var item = await itemRepository.GetAsync(id);

            if(item == null)
            {
                return NotFound();
            }

            var response = new ItemDto
            {
                ID = item.Id,
                Name = item.Name,
                Description = item.Description,
                SerialNumber = item.SerialNumber,
                Value = item.Value,
                CategoryID = item.CategoryId,
                CategoryName = item.Inventory_Category.Name,
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            var item = await itemRepository.DeleteAsync(id);

            if(item == null)
            {
                return NotFound();
            }

            var response = new ItemDto
            {
                ID = item.Id,
                Name = item.Name,
                Description = item.Description,
                SerialNumber = item.SerialNumber,
                Value = item.Value,
                CategoryID = item.CategoryId,
                CategoryName = item.Inventory_Category.Name,
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateItem([FromRoute] int id, ItemRequestDto itemDto)
        {
            var item = new Inventory_Item
            {
                Id = id,
                Name = itemDto.Name,
                Description = itemDto.Description,
                SerialNumber = itemDto.SerialNumber,
                Value = itemDto.Value,
                CategoryId  = itemDto.CategoryID
            };

            item = await itemRepository.UpdateAsync(item);

            if(item == null)
            {
                return NotFound();
            }

            var response = new ItemDto
            {
                ID = item.Id,
                Name = item.Name,
                Description = item.Description,
                SerialNumber = item.SerialNumber,
                Value = item.Value,
                CategoryID = item.CategoryId,
                CategoryName = item.Inventory_Category.Name
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("categories/{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var category = await itemRepository.GetCategoryAsync(id);

            if(category == null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                ID = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("categories/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var category = await itemRepository.DeleteCategoryAsync(id);

            if( category == null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                ID = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("categories/{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, CategoryRequestDto categoryDto)
        {
            var category = new Inventory_Category
            {
                Id = id,
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            category = await itemRepository.UpdateCategoryAsync(category);

            if(category == null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                ID = category.Id,
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            return Ok(response);
        }
    }
}
