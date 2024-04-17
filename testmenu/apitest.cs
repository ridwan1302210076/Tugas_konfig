namespace testmenu
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
            var controller = new menuController();

            // Act
            var result = controller.Get() as ActionResult<List<menu>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value.Count > 0);
        }

        [TestMethod]
        public void GetMenuById_WithValidId_ReturnsMenu()
        {
            // Arrange
            var controller = new menuController();
            int id = 1;

            // Act
            var result = controller.GetMenuById(id) as ActionResult<menu>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(id, result.Value.id);
        }

        [TestMethod]
        public void GetMenuById_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var controller = new menuController();
            int id = 100;

            // Act
            var result = controller.GetMenuById(id);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Post_WithValidMenu_ReturnsCreatedAtAction()
        {
            // Arrange
            var controller = new menuController();
            var menu = new menu { id = 3, Nama = "New Menu", harga = 10 };

            // Act
            var result = controller.Post(menu) as ActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));
        }

        [TestMethod]
        public void Put_WithValidIdAndMenu_ReturnsNoContent()
        {
            // Arrange
            var controller = new menuController();
            int id = 1;
            var menu = new menu { id = id, Nama = "Updated Menu", harga = 16 };

            // Act
            var result = controller.Put(id, menu) as ActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void Delete_WithValidId_ReturnsNoContent()
        {
            // Arrange
            var controller = new menuController();
            int id = 1;

            // Act
            var result = controller.Delete(id) as ActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
    }
}