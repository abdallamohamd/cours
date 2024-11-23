using System.ComponentModel.DataAnnotations;

namespace WebApplication1.v_model
{
    public class regvm
    {
        public string name {  get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        public string address { get; set; }
        public string phone {  get; set; }
    }
}
