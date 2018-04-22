using System;

namespace SalesTaxApp
{
	class Product
	{
		private ProductType _typeOfProduct = ProductType.TaxPaidProduct;
		private string _productName = string.Empty;
		private double _productPrice;
		private int _quantity;
		private bool _isImportedProduct = false;

		public string ProductName { get { return _productName; } }
		public double ProductPrice { get { return _productPrice; } }
		public int Quantity { get { return _quantity; } }

		public Product(string productName, double productPrice, int quantity, ProductType type, bool isImportedProduct)
		{
			_productName = productName;
			_productPrice = productPrice;
			_quantity = quantity;
			_typeOfProduct = type;
			_isImportedProduct = isImportedProduct;
		}

		public double ComputeSalesTax()
		{
			double tax = 0;
			if (_isImportedProduct) 
				tax += _productPrice * .05;
			switch (_typeOfProduct)
			{
				case ProductType.ExemptedProduct: break;
				case ProductType.TaxPaidProduct:
					tax += _productPrice * .10;
					break;
			}
			return Math.Round(tax, 2);
		}
	}
}