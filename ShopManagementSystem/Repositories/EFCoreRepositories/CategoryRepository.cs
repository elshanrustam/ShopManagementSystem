using ShopManagementSystem.Entities;
using ShopManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementSystem.Repositories.EFCoreRepositories
{
    internal class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
    }
}
