using System.Collections.Generic;

namespace BACWebsite.Models
{
    public interface IMenuItemRepository
    {
        IEnumerable<MenuItem> AllMenuItems { get; }
    }
}
