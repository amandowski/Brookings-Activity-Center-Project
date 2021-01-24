using System.Collections.Generic;

namespace BACWebsite.Models
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly BACContext _appDbContext;
        public MenuItemRepository(BACContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<MenuItem> AllMenuItems
        {
            get
            {
                return _appDbContext.MenuItem;
            }
        }
    }
}
