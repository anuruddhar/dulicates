using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{	
		List<OrderLine> list = new List<OrderLine>();
		OrderLine order1 = new OrderLine();
		order1.OrderNumber = "SV8905";
		order1.ProductNumber = "6C3301";
		list.Add(order1);
		
		OrderLine order2 = new OrderLine();
		order2.OrderNumber = "SV8905";
		order2.ProductNumber = "6C3301";
		list.Add(order2);
		
		OrderLine order3 = new OrderLine();
		order3.OrderNumber = "SV8905";
		order3.ProductNumber = "MC2671";
		list.Add(order3);
		
		OrderLine order4 = new OrderLine();
		order4.OrderNumber = "XV8905";
		order4.ProductNumber = "6C3301";
		list.Add(order4);
		
		Console.WriteLine("---Data----");
		foreach(var order in list){
			Console.WriteLine(order.OrderNumber + " -  " + order.ProductNumber);
		}
		
		Console.WriteLine("---Duplicates----");
		
		var duplicates = list.GroupBy(x => new {x.OrderNumber,x.ProductNumber})
              .Where(g => g.Count() > 1)
              .SelectMany(y => y)
              .Distinct();

		foreach(var order in duplicates){
			Console.WriteLine(order.OrderNumber + " -  " + order.ProductNumber);
		}
			
		Console.WriteLine("---Distincts----");
		
		var distincts = list.DistinctBy(p => new { p.OrderNumber, p.ProductNumber });
			foreach(var order in distincts){
			Console.WriteLine(order.OrderNumber + " -  " + order.ProductNumber);
		}		
	}
}

public static class Extensions {
	public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		HashSet<TKey> seenKeys = new HashSet<TKey>();
		foreach (TSource element in source)
		{
			if (seenKeys.Add(keySelector(element)))
			{
				yield return element;
			}
		}
	}
}

public class OrderLine{
	public string OrderNumber;
	public string ProductNumber;
}
