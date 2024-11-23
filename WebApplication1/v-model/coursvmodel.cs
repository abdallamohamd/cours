using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.v_model
{
    public class coursvmodel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime startDate { get; set; }

        public int categoryid { get; set; }

        public int labid { get; set; }

        public int insid { get; set; }


    }
}
