using menu_pembelian;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Contracts;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class menuController : ControllerBase
    {
        private const string filePath = "menu.json";

        // meng-get data menu keseluruhan yang diambil dari menu
        [HttpGet]
        public ActionResult<List<menu>> Get()
        {
            return MenuManager.GetMenus();
        }
        //mengambil data berdasarkan nama  menu
        [HttpGet("{nama}")]
        public ActionResult<menu> GetMenuByNama(string nama)
        {
            menu m = MenuManager.getmenusbyNama(nama);
            if (m != null)
            {
                return m;
            }
            else
            {
                return NotFound();
            }
        }
        // POST: api/Menu
        [HttpPost]
        public ActionResult Post([FromBody] menu menu)
        {
            Contract.Requires(menu != null, "Menu object is null.");
            MenuManager.addmenu(menu);
            MenuManager.Serialize();

            return CreatedAtAction(nameof(Get), null);
        }

        // PUT: api/Menu
        [HttpPut("{nama}")]
        public ActionResult Put(string nama, [FromBody] menu menu)
        {
            Contract.Requires(menu != null, "Menu object is null.");
            MenuManager.UpdateMenu(nama, menu);
            MenuManager.Serialize();

            return NoContent();
        }

        // DELETE: api/Menu
        [HttpDelete("{nama}")]
        public ActionResult Delete(string nama)
        {
            MenuManager.DeleteMenu(nama);
            MenuManager.Serialize();

            return NoContent();
        }



    }
}
