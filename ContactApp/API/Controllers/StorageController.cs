using ContactApp.API.Storage;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.API.Controllers
{
    public class StorageController:BaseController
    {
        private DataContext dataContext;

        public StorageController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet("SetString/{value}")]
        public void SetString(string value)
        {
            dataContext.Str = value;
        }

        [HttpGet("GetString")]
        public string GetString()
        {
            return dataContext.Str;
        }
    }
}
