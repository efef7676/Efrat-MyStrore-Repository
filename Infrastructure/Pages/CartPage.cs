using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Extensions;
using OpenQA.Selenium.Support.UI;

namespace Infrastructure
{
    public class CartPage : BasePage, IHasProducts<ProductRow>
    {
        private List<ProductRow> _products;
        public List<ProductRow> Products
        {
            get
            {
                var elements = Driver.FindElements(By.CssSelector("#cart_summary tbody tr"));
                return elements == null ? _products : elements.Select(s => new ProductRow(Driver, s)).ToList();
            }
            set
            {
                _products = value;
            }
        }

        public CartPage(IWebDriver driver) : base(driver)
        {
            _products = new List<ProductRow>();
        }

        public ProductRow GetProductBy(Uri imageUri) => Products.FirstOrDefault(p => p.GetImageUri() == imageUri);

        public CartPage DeleteProductBy(Uri imageUri)
        {
            GetProductBy(imageUri).ClickOnDeleteButton();
            Driver.WaitUntilElementDoesntExists(By.CssSelector($"tbody a[href='{imageUri}']"));

            return new CartPage(Driver);
        }

        public ProductRow ChangeQtyInOne(bool RaiseQty, Uri imageUri)
        {
            var currentProduct = GetProductBy(imageUri);
            var newQty = currentProduct.QtyBox.GetQtyValue();

            if (RaiseQty)
            {
                newQty += 1;
                currentProduct.QtyBox.ClickOnUpButton();
            }
            else if (!RaiseQty && newQty > 1)
            {
                newQty -= 1;
                currentProduct.QtyBox.ClickDownUpButton();
            }
            else
            {
                return null;
                //throw an exception?
            }

            currentProduct
                .QtyBox
                .ParentElement
                .WaitUntilElementIs(By.CssSelector(".cart_quantity_input.form-control.grey"), $"{newQty}");

            return currentProduct;
        }

        public ProductRow ChangeQtyTo(double changeTo, Uri imageUri)
        {
            var currentProduct = GetProductBy(imageUri);
            var newQty = changeTo;

            currentProduct.QtyBox.ChangeQty(changeTo);

            currentProduct
                .QtyBox
                .ParentElement
                .WaitUntilElementIs(By.CssSelector(".cart_quantity_input.form-control.grey"), $"{newQty}");

            return currentProduct;
        }
    }
}
