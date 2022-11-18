using _20221118_NeptunoMVC.Dal;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace _20221118_NeptunoMVC.Models
{
    public class CategoriesModel
    {
        public List<Category> GetCategories()
        {

            var dbContext = new cifo_OGSContext();
            var categories = dbContext.Categories
                .OrderBy(c => c.CategoryName).ToList();
            return categories;
        }
    }
}
