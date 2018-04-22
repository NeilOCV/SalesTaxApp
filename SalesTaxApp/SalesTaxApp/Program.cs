using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxApp
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				List<List<Product>> Sales = GenerateSalesLists();
				int saleCount = 0;
				foreach (List<Product> productList in Sales)
				{
					double totalBill = 0, salesTax = 0;
					saleCount++;
					Console.WriteLine("Receipt number "+string.Format("{0:yyyyMMddHHmmss}",DateTime.Now)+" - "+saleCount);
					Console.WriteLine("╔═══╤════════════════════════════════════════╤═════╤═════╗");
					Console.WriteLine("║Qty│Product description                     │Price│ Tax ║");
					Console.WriteLine("╠═══╪════════════════════════════════════════╪═════╪═════╣");
					foreach (Product prod in productList)
					{
						double tax = prod.ComputeSalesTax();
						salesTax += tax;
						totalBill += tax + (prod.Quantity * prod.ProductPrice);
						Console.WriteLine(MakeGridItem(prod,tax));
					}
					Console.WriteLine("╠═══╧════════════════════════════════════════╪═════╪═════╣");
					Console.WriteLine("║Total                                       │" + PadString(totalBill.ToString(), 5, false) + "│" + PadString(salesTax.ToString(), 5, false) + "║");
					Console.WriteLine("╚════════════════════════════════════════════╧═════╧═════╝");
					Console.WriteLine();
					
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			Console.ReadLine();
		}

		private static string MakeGridItem(Product product,double tax)
		{
			/*
			 * Just to make it look funky - use some ascii characters.
			 * 		 * 2483 │
					 * 2484 ┤
					 * 2485 ╡
					 * 2486 ╢
					 * 2487 ╖
					 * 2488 ╕
					 * 2489 ╣
					 * 2490 ║
					 * 2491 ╗
					 * 2492 ╝
					 * 2493 ╜
					 * 2494 ╛
					 * 2495 ┐
					 * 2496 └
					 * 2497 ┴
					 * 2498 ┬
					 * 2499 ├
					 * 2500 ─
					 * 2501 ┼
					 * 2502 ╞
					 * 2503 ╟
					 * 2504 ╚
					 * 2505 ╔
					 * 2506 ╩
					 * 2507 ╦
					 * 2508 ╠
					 * 2509 ═
					 * 2510 ╬
					 * 2511 ╧
					 * 2512 ╨
					 * 2513 ╤
					 * 2514 ╥
					 * 2515 ╙
					 * 2516 ╘
					 * 2517 ╒
					 * 2518 ╓
					 * 2519 ╫
					 * 2520 ╪
					 * 
					 * */
			StringBuilder builder = new StringBuilder();

			builder.Append("║");
			builder.Append(PadString(product.Quantity.ToString(), 3, false));
			builder.Append("│");
			builder.Append(PadString(product.ProductName, 40, true));
			builder.Append("│");
			builder.Append(PadString((product.ProductPrice+tax).ToString(), 5, false));
			builder.Append("│");
			builder.Append(PadString(tax.ToString(), 5, false));
			builder.Append("║");
			return builder.ToString();
		}

		private static string PadString(string input,int width, bool padLeft)
		{
			string result = string.Empty;
			string pad = string.Empty;
			int numberOfCharacersToPad = width - input.Length;
			if (numberOfCharacersToPad < 0)
			{
				result = input.Substring(0, width);
			}
			{
				for (int i = 0; i < numberOfCharacersToPad; i++)
				{
					pad += " ";
				}
				if (!padLeft)
				{
					result = pad + input;
				}
				else
				{
					result = input + pad;
				}
			}
			return result;


		}

		private static List<List<Product>> GenerateSalesLists()
		{
			List<List<Product>> salesLists=new List<List<Product>>();

			List<Product> input1 = new List<Product>();
			input1.Add(new Product("Book", 12.49, 1, ProductType.ExemptedProduct, false));
			input1.Add(new Product("Music CD", 14.99, 1, ProductType.TaxPaidProduct, false));
			input1.Add(new Product("Chocolate Bar", 0.85, 1, ProductType.ExemptedProduct, false));
			salesLists.Add(input1);

			List<Product> input2 = new List<Product>();
			input2.Add(new Product("Imported Chocolate", 10, 1, ProductType.ExemptedProduct,true));
			input2.Add(new Product("Imported Perfume", 47.50, 1, ProductType.TaxPaidProduct,true));
			salesLists.Add(input2);

			List<Product> input3 = new List<Product>();
			input3.Add(new Product("Imported Perfume", 27.99, 1, ProductType.TaxPaidProduct,true));
			input3.Add(new Product("Perfume", 18.99, 1, ProductType.TaxPaidProduct,false));
			input3.Add(new Product("Headache Pills", 9.75, 1, ProductType.ExemptedProduct,false));
			input3.Add(new Product("Imported Chocolate", 11.25, 1, ProductType.ExemptedProduct,true));
			salesLists.Add(input3);

			return salesLists;
		}
	}
}
