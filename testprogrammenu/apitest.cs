using apiMenu.Controllers;
using menu_pembelian;
using Microsoft.AspNetCore.Mvc;
using System;

namespace testprogrammenu
{
    [TestClass]
    public class apitest
    {
        private menuController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Initialize the menuController instance
            controller = new menuController();

            // Add a menu with ID 1
            var menu = new menu { id = 1, Nama = "Sample Menu", harga = 10 };
            controller.Post(menu);
        }

        [TestMethod]
        public void Get_ReturnsListOfMenus()
        {
            // Arrange

            // Act
            var result = controller.Get() as ActionResult<List<menu>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value.Count > 0);
        }

        [TestMethod]
        public void GetMenuByNama_WithValidNama_ReturnsMenu()
        {
            // Arrange
            string nama = "Sample Menu";

            // Act
            var result = controller.GetMenuByNama(nama) as ActionResult<menu>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(nama, result.Value.Nama);
        }

        [TestMethod]
        public void GetMenuByNama_WithInvalidNama_ReturnsNotFound()
        {
            // Arrange
            string nama = "Invalid Menu";

            // Act
            var result = controller.GetMenuByNama(nama);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Post_WithValidMenu_ReturnsCreatedAtAction()
        {
            // Arrange
            var menu = new menu { id = 3, Nama = "New Menu", harga = 10 };

            // Act
            var result = controller.Post(menu) as ActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));
        }

        [TestMethod]
        public void Put_WithValidNamaAndMenu_ReturnsNoContent()
        {
            // Arrange
            string nama = "Sample Menu";
            var menu = new menu { id = 1, Nama = "Updated Menu", harga = 16 };

            // Act
            var result = controller.Put(nama, menu) as ActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void Delete_WithValidNama_ReturnsNoContent()
        {
            // Arrange
            string nama = "Sample Menu";

            // Act
            var result = controller.Delete(nama) as ActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
    }
}