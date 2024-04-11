using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSupply.BLL
{
    public class InventoryController
    {

        HiTechDBEntities1 db = new HiTechDBEntities1();
        public List<string> FilterStatuses(int num1, int num2)
        {
            var filteredStatuses = db.Statuses
            .Where(stat => stat.StatusId == num1 || stat.StatusId == num2)
            .Select(stat => stat.Description)
            .ToList();

            return filteredStatuses;
            
        }













    }
}
